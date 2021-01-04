using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;

using Newtonsoft.Json.Linq;

using NUnit.Framework;

using SensorThings.Client;
using SensorThings.Core;

using Shouldly;

using static SensorThings.Client.QueryHelper;

namespace sensorthings_net_sdk.tests {
    public class EntityHandlerTest {
        private const string ThingName = "Hello-Integration-Tests";

        private ISensorThingsEntityHandler entityHandler;

        [SetUp]
        public void Initialize() {
            entityHandler = new SensorThingsEntityHandler("http://scratchpad.sensorup.com/OGCSensorThings/v1.0/");

            // ignore test if service not reachable
            try {
                entityHandler.SearchEntities<Thing>().Wait();
            } catch (AggregateException e) {
                var firstException = e.InnerExceptions.FirstOrDefault();
                if (firstException is HttpRequestException) Assert.Inconclusive(firstException.Message);
            }
        }

        [TearDown]
        public void TearDown() {
            Console.WriteLine("dispose things");

            try {
                var things = entityHandler.SearchEntities<Thing>(AttributeFilter("name", ThingName)).Result.Items;
                foreach (var thing in things) {
                    Console.WriteLine($"delete {thing.Name} ({thing.Id})");
                    entityHandler.DeleteEntity<Thing>(thing.Id).Wait();
                }
                entityHandler.SearchEntities<Thing>(AttributeFilter("name", ThingName)).Result.Items.Count.ShouldBe(0);
            } catch (Exception) {
                // ignored
            }
        }

        [Test]
        public void ShouldCreateAndReturnThingWithId() {
            var expectedThing = new Thing { Name = ThingName, Description = "Hello World!", };
            var actualThing = entityHandler.CreateEntity(expectedThing).Result;

            actualThing.ShouldNotBeNull();
            expectedThing.Name.ShouldBe(actualThing.Name);
            expectedThing.Description.ShouldBe(actualThing.Description);

            // special
            expectedThing.Id.ShouldBeNull();
            actualThing.Id.ShouldNotBeNull();
        }

        [Test]
        public void ShouldGetThingForId() {
            var expectedThing = entityHandler
                .CreateEntity(new Thing { Name = ThingName, Description = "Hello World!", })
                .Result;

            Console.WriteLine($"find by id '{expectedThing.Id}'");
            var actualThing = entityHandler.GetEntity<Thing>(expectedThing.Id).Result;

            ShouldBeValid(actualThing, expectedThing);
        }

        [Test]
        public void ShouldFindTopNThings() {
            _ = entityHandler
                .CreateEntity(new Thing { Name = ThingName, Description = "Hello World!", })
                .Result;
            _ = entityHandler
                .CreateEntity(new Thing { Name = ThingName, Description = "Hello World!", })
                .Result;

            Console.WriteLine("find topN things");
            var actualThing = entityHandler.SearchEntities<Thing>(TopN(1)).Result;

            actualThing.ShouldNotBeNull();
            actualThing.Items.Count.ShouldBe(1);
            actualThing.Items.First().ShouldNotBeNull();
        }

        [Test]
        public void ShouldFindThingsForName() {
            var expectedThing = entityHandler
                .CreateEntity(new Thing { Name = ThingName, Description = "Hello World!", })
                .Result;

            Console.WriteLine($"find by name '{expectedThing.Name}'");
            var actualThing = entityHandler.SearchEntity<Thing>(AttributeFilter("name", expectedThing.Name)).Result;

            ShouldBeValid(actualThing, expectedThing);
        }

        // ReSharper disable once UnusedMember.Global
        [Ignore("Does not work at GOST server yet.")]
        public void ShouldFindThingsForProperty() {
            var expectedThing = entityHandler.CreateEntity(new Thing {
                    Name = ThingName,
                    Description = "Hello World!",
                    Properties = new Dictionary<string, object> { { "hello", "world" } },
                })
                .Result;

            Console.WriteLine("find by properties filter");
            var (key, value) = expectedThing.Properties.First();
            var actualThing = entityHandler.SearchEntity<Thing>(PropertyFilter(key, value.ToString())).Result;

            ShouldBeValid(actualThing, expectedThing);
        }

        [Test]
        public void ShouldFindLocationCreatedInsideOfThing() {
            var expectedLocation = new Location {
                Name = "Location Name",
                Description = "Location Description",
                EncodingType = "Location EncodingType",
                Feature = JObject.Parse(@"{""hello"":""Feature""}"),
            };

            var expectedThing = entityHandler.CreateEntity(new Thing {
                    Name = ThingName,
                    Description = "Hello World!",
                    Locations = new ObservableCollection<Location> { expectedLocation },
                })
                .Result;

            Console.WriteLine($"find locations by thing '{expectedThing.Id}'");
            var actualLocation = entityHandler.SearchEntity<Location, Thing>(expectedThing).Result;

            ShouldBeValid(actualLocation, expectedLocation);
        }

        [Test]
        public void ShouldFindLocationCreatedOutsideOfThing() {
            var expectedThing = entityHandler
                .CreateEntity(new Thing { Name = ThingName, Description = "Hello World!", })
                .Result;
            var expectedLocation = entityHandler.CreateEntity(expectedThing,
                    new Location {
                        Name = "Location Name",
                        Description = "Location Description",
                        EncodingType = "Location EncodingType",
                        Feature = JObject.Parse(@"{""hello"":""Feature""}"),
                    })
                .Result;

            Console.WriteLine($"find locations by thing id '{expectedThing.Id}'");
            var actualLocation = entityHandler.SearchEntity<Location, Thing>(expectedThing).Result;

            ShouldBeValid(actualLocation, expectedLocation);
        }

        [Test]
        public void ShouldFindOnlyOneSensorAtDataStream() {
            var expectedThing = entityHandler
                .CreateEntity(new Thing { Name = ThingName, Description = "Hello World!", })
                .Result;
            var expectedSensor = new Sensor {
                Name = "Sensor Name",
                Description = "Sensor Description",
                EncodingType = "application/pdf",
                Metadata = "https://arxiv.org/pdf/1234.pdf",
            };
            var expectedDatastream = new Datastream {
                Name = "Datastream Name",
                Description = "Datastream Description",
                ObservationType = "http://www.opengis.net/def/observationType/OGC-OM/2.0/OM_Measurement",
                UnitOfMeasurement =
                    new UnitOfMeasurement { Name = "UoM", Symbol = "uom", Definition = "https://ucum.org/trac" },
                Sensor = expectedSensor,
                ObservedProperty = new ObservedProperty {
                    Name = "ObservedProperty Name",
                    Description = "ObservedProperty Description",
                    Definition = "http://example.com/"
                },
                Observations = null
            };

            var datastream = entityHandler.CreateEntity(expectedThing, expectedDatastream).Result;

            Console.WriteLine($"find sensor by datastream '{datastream.Id}'");
            var actualSensor = entityHandler.SearchEntity<Sensor, Datastream>(datastream).Result;

            ShouldBeValid(actualSensor, expectedSensor);

            var actualDatastreams = entityHandler.SearchEntities<Datastream, Sensor>(actualSensor).Result;
            var actualDatastream = actualDatastreams.Items.First();
            actualDatastream.Name.ShouldBe(expectedDatastream.Name);
            actualDatastream.Description.ShouldBe(expectedDatastream.Description);
        }
        
        
        [Test]
        public void ShouldFindOnlyOneThing() {
            _ = entityHandler
                .CreateEntity(new Thing { Name = ThingName, Description = "Hello World!", })
                .Result;
            _ = entityHandler
                .CreateEntity(new Thing { Name = ThingName, Description = "Hello World!", })
                .Result;

            Console.WriteLine($"find by name '{ThingName}'");
            var actualThing = entityHandler.SearchEntity<Thing>(AttributeFilter("name", ThingName)).Result;

            actualThing.ShouldNotBeNull();
            actualThing.Id.ShouldNotBeNull();
            actualThing.Name.ShouldBe(ThingName);
        }

        [Test]
        public void ShouldDeleteThing() {
            var expectedThing = entityHandler
                .CreateEntity(new Thing { Name = ThingName, Description = "Hello World!", })
                .Result;
            expectedThing.ShouldNotBeNull();
            expectedThing.Id.ShouldNotBeNull();

            var id = expectedThing.Id;
            Console.WriteLine($"delete by id '{id}'");
            entityHandler.DeleteEntity<Thing>(id).Wait();
            
            var actualThing = entityHandler.GetEntity<Thing>(id).Result;
            actualThing.ShouldBeNull();
        }

        [Test]
        public void ShouldUpdateThing() {
            var oldDescription = "Hello World!";
            var newDescription = "Hello Underworld!";
            var expectedThing = entityHandler
                .CreateEntity(new Thing { Name = ThingName, Description = oldDescription, })
                .Result;
            expectedThing.ShouldNotBeNull();
            expectedThing.Description.ShouldBe(oldDescription);

            expectedThing.Description = newDescription;
            Console.WriteLine($"update by name '{expectedThing.Name}'");
            entityHandler.UpdateEntity(expectedThing);
            
            var actualThing = entityHandler.GetEntity<Thing>(expectedThing.Id).Result;
            actualThing.Description.ShouldBe(newDescription);
            
            ShouldBeValid(actualThing, expectedThing);
        }

        private void ShouldBeValid(Thing actual, Thing expected) {
            actual.ShouldNotBeNull();
            actual.Id.ShouldBe(expected.Id);
            actual.Name.ShouldBe(expected.Name);
            actual.Description.ShouldBe(expected.Description);
            actual.Properties.ShouldBe(expected.Properties);
        }

        private void ShouldBeValid(Location actual, Location expected) {
            actual.ShouldNotBeNull();
            actual.Name.ShouldBe(expected.Name);
            actual.Description.ShouldBe(expected.Description);
            actual.EncodingType.ShouldBe(expected.EncodingType);
            actual.Feature.ShouldBe(expected.Feature);
        }

        private void ShouldBeValid(Sensor actual, Sensor expected) {
            actual.ShouldNotBeNull();
            actual.Id.ShouldNotBeNull();
            actual.Name.ShouldBe(expected.Name);
            actual.Description.ShouldBe(expected.Description);
            actual.EncodingType.ShouldBe(expected.EncodingType);
            actual.Metadata.ShouldBe(expected.Metadata);
        }
    }
}
