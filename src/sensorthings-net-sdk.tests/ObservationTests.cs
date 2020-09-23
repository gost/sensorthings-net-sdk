using NUnit.Framework;
using SensorThings.Client;
using System;
using SensorThings.Core;

namespace sensorthings_net_sdk.tests
{
    public class ObservationTests
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
        public void GetObservationTest()
        {
            // act
            var response = client.GetObservation("2706628").Result;
            var observation = response.Result;

            var datastreamResponse = observation.GetDatastream(client).Result;

            var foiResponse = observation.GetFeatureOfInterest(client).Result;

            // assert
            Assert.IsTrue(observation.Id == "2706628");
            Assert.IsTrue(observation.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations(2706628)");
            Assert.IsTrue((string)observation.Result == "22");
            Assert.IsTrue(observation.DatastreamNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations(2706628)/Datastream");
            Assert.IsTrue(observation.FeatureOfInterestNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations(2706628)/FeatureOfInterest");
        }

        [Test]
        public void GetObservationCollectionTest()
        {
            // act
            var response = client.GetObservationCollection().Result;
            var observations = response.Result;

            // assert
            Assert.IsTrue(observations.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations?$top=100&$skip=100");
            Assert.IsTrue(observations.Items.Count == 100);
        }
    }
}
