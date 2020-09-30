using System.Net;

using NUnit.Framework;

using SensorThings.Client;
using SensorThings.Core;

namespace sensorthings_net_sdk.tests {
    public class ThingsTests {
        private string server;
        private SensorThingsClient client;

        [SetUp]
        public void Initialize() {
            server = "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/";
            client = new SensorThingsClient(server);
        }

        [Test]
        public void GetThingTest() {
            // act
            var response = client.GetThing("760792").Result;
            var thing = response.Result;

            var datastreamsResponse = thing.GetDatastreams(client).Result;
            var datastreams = datastreamsResponse.Result;
            var historicalLocationsResponse = thing.GetHistoricalLocations(client).Result;
            var historicalLocations = historicalLocationsResponse.Result;
            var locationsresponse = thing.GetLocations(client).Result;
            var locations = locationsresponse.Result;

            // assert
            Assert.IsTrue(thing.Id == "760792");
            Assert.IsTrue(thing.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Things(760792)");
            Assert.IsTrue(thing.Description == "This is a CCTV camera mounted at the Front Entrance from AMK Avenue 8");
            Assert.IsTrue(thing.Name == "CCTV @ NYP Campus - Main Entrance");
            Assert.IsTrue(thing.DatastreamsNavigationLink ==
                          "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Things(760792)/Datastreams");
            Assert.IsTrue(thing.HistoricalLocationsNavigationLink ==
                          "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Things(760792)/HistoricalLocations");
            Assert.IsTrue(thing.LocationsNavigationLink ==
                          "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Things(760792)/Locations");
            Assert.IsTrue(datastreams.Count == 0);
            Assert.IsTrue(historicalLocations.Count > 0);
            Assert.IsTrue(locations.Count > 0);
        }

        [Test]
        public void GetThingsTest() {
            // act
            var response = client.GetThingCollection().Result;
            var things = response.Result;

            // assert
            Assert.IsTrue(things.Count > 0);
            Assert.IsTrue(things.NextLink ==
                          "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Things?$top=100&$skip=100");
            Assert.IsTrue(things.Items.Count == 100);
        }

        [Test]
        public void CreateEmptyThingTest() {
            // act
            var exampleThing = new Thing() { };
            var response = client.Create(exampleThing).Result;
            var thing = response.Result;

            // assert
            Assert.IsTrue(response.HttpStatusCode == HttpStatusCode.BadRequest);
            Assert.IsNull(thing);
        }

        [Test]
        // we get a thing with the same Id but then we can't get it by that Id
        // - a workaround, lways removing the Id, fixes that problem
        public void CreateThingIgnoringGivenIdTest() {
            // act
            var exampleThing = new Thing() { Id = "1234", Name = "hello", Description = "Foo bar" };
            var response = client.Create(exampleThing).Result;
            var thing = response.Result;

            // assert
            Assert.IsNull(exampleThing.Id); // the Id is removed during create (see workaround)
            Assert.IsNotNull(thing);
            Assert.IsNotNull(thing.Id);
            Assert.IsTrue(thing.Name == exampleThing.Name);
            Assert.IsTrue(thing.Description == exampleThing.Description);

            var getResponse = client.GetThing(thing.Id).Result;
            var thing2 = getResponse.Result;

            Assert.IsNotNull(thing2);
            Assert.IsNotNull(thing2.Id);
            Assert.IsTrue(thing2.Id == thing.Id);
        }

        [Test]
        public void CreateThingTest() {
            // act
            var exampleThing = new Thing() { Name = "hello", Description = "Foo bar" };
            var response = client.Create(exampleThing).Result;
            var thing = response.Result;

            // assert
            Assert.IsNotNull(thing);
            Assert.IsNotNull(thing.Id);
            Assert.IsFalse(thing.Id.Equals(exampleThing.Id));
            Assert.IsTrue(thing.Name == exampleThing.Name);
            Assert.IsTrue(thing.Description == exampleThing.Description);
        }
    }
}
