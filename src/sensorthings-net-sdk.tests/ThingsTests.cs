using NUnit.Framework;
using SensorThings.Client;
using System;

namespace sensorthings_net_sdk.tests
{
    public class ThingsTests
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
        public void GetThingTest()
        {
            // act
            var thing = client.GetThing(760792);
            var datastreams = thing.GetDatastreams();
            var historicalLocations = thing.GetHistoricalLocations();
            var locations = thing.GetLocations();

            // assert
            Assert.IsTrue(thing.Id == 760792);
            Assert.IsTrue(thing.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Things(760792)");
            Assert.IsTrue(thing.Description == "This is a CCTV camera mounted at the Front Entrance from AMK Avenue 8");
            Assert.IsTrue(thing.Name == "CCTV @ NYP Campus - Main Entrance");
            Assert.IsTrue(thing.Properties.Count == 0);
            Assert.IsTrue(thing.DatastreamsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Things(760792)/Datastreams");
            Assert.IsTrue(thing.HistoricalLocationsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Things(760792)/HistoricalLocations");
            Assert.IsTrue(thing.LocationsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Things(760792)/Locations");
            Assert.IsTrue(datastreams.Count == 0);
            Assert.IsTrue(historicalLocations.Count > 0);
            Assert.IsTrue(locations.Count > 0);
            
        }

        [Test]
        public void GetThingsTest()
        {
            // act
            var things = client.GetThingCollection();

            // assert
            Assert.IsTrue(things.Count >0);
            Assert.IsTrue(things.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Things?$top=100&$skip=100");
            Assert.IsTrue(things.Items.Count == 100);
        }
    }
}