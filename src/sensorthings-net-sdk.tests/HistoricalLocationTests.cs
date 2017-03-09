using NUnit.Framework;
using SensorThings.Client;
using System;

namespace sensorthings_net_sdk.tests
{
    public class HistoricalLocationTests
    {
        private string server;
        private SensorThingsClient client;

        [SetUp]
        public void Initialize()
        {
            server = "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/";
            client = new SensorThingsClient(server);
        }

        [Test]
        public void GetHistoricalLocationTest()
        {
            // act
            var historicalLocation = client.GetHistoricalLocation(761098);
            var locations = historicalLocation.GetLocations();
            var thing = historicalLocation.GetThing();

            // assert
            Assert.IsTrue(historicalLocation.Id == 761098);
            Assert.IsTrue(historicalLocation.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/HistoricalLocations(761098)");
            // 2017-03-07T06:02:30.984Z
            Assert.IsTrue(historicalLocation.Time == new DateTime(2017, 3, 7, 6, 2, 30, 984));
            Assert.IsTrue(historicalLocation.LocationsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/HistoricalLocations(761098)/Locations");
            Assert.IsTrue(historicalLocation.ThingNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/HistoricalLocations(761098)/Thing");
            Assert.IsTrue(locations.Count > 0);
            Assert.IsTrue(thing.Id == 760740);
        }

        [Test]
        public void GetHistoricalLocationCollectionTest()
        {
            // act
            var historicalLocations = client.GetHistoricalLocationsCollection();

            // assert
            // If new observations are added this next test will fail....
            Assert.IsTrue(historicalLocations.Count>0);
            Assert.IsTrue(historicalLocations.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/HistoricalLocations?$top=100&$skip=100");
            Assert.IsTrue(historicalLocations.Items.Count == 100);
            Assert.IsTrue(historicalLocations.Items[0]!=null);
        }
    }
}
