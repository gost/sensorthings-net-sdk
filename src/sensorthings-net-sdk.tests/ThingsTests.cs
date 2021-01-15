using NUnit.Framework;

using SensorThings.Client;
using SensorThings.Client.Extensions;
using SensorThings.Core;

namespace sensorthings_net_sdk.tests {
    public class ThingsTests {
        private string server;
        private SensorThingsEntityHandler entityHandler;

        [SetUp]
        public void Initialize() {
            server = "http://scratchpad.sensorup.com/OGCSensorThings/v1.0";
            entityHandler = new SensorThingsEntityHandler(server);
        }

        [Test]
        public void GetThingTest() {
            // act
            const string id = "760792";
            var thing = entityHandler.GetEntity<Thing>(id).Result;

            var datastreams = thing.GetDatastreams(entityHandler).Result;
            var historicalLocations = thing.GetHistoricalLocations(entityHandler).Result;
            var locations = thing.GetLocations(entityHandler).Result;

            // assert
            Assert.IsTrue(thing.Id == id);
            Assert.IsTrue(thing.SelfLink == $"{server}/Things({id})");
            Assert.IsTrue(thing.Description == "This is a CCTV camera mounted at the Front Entrance from AMK Avenue 8");
            Assert.IsTrue(thing.Name == "CCTV @ NYP Campus - Main Entrance");
            Assert.IsTrue(thing.DatastreamsNavigationLink == $"{server}/Things({id})/Datastreams");
            Assert.IsTrue(thing.HistoricalLocationsNavigationLink == $"{server}/Things({id})/HistoricalLocations");
            Assert.IsTrue(thing.LocationsNavigationLink == $"{server}/Things({id})/Locations");
            Assert.IsTrue(datastreams.Count == 0);
            Assert.IsTrue(historicalLocations.Count > 0);
            Assert.IsTrue(locations.Count > 0);
        }

        [Test]
        public void GetThingsTest() {
            // act
            var things = entityHandler.SearchEntities<Thing>().Result;

            // assert
            Assert.IsTrue(things.Count > 0);
            Assert.IsTrue(things.NextLink == $"{server}/Things?$top=100&$skip=100");
            Assert.IsTrue(things.Items.Count == 100);
        }
    }
}
