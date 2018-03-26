using NUnit.Framework;
using SensorThings.Client;
using System;

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
            var observation = client.GetObservation("760789").Result;
            var datastream = observation.GetDatastream().Result;
            var foi = observation.GetFeatureOfInterest().Result;

            // assert
            Assert.IsTrue(observation.Id == "760789");
            Assert.IsTrue(observation.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations(760789)");
            // Phenomenon time should be 2020-01-25T19:00:00.000Z in Iso8601
            Assert.IsTrue(observation.PhenomenonTime == new DateTime(2020, 1, 25, 19, 0, 0));
            Assert.IsTrue((string)observation.Result == "99");
            // Assert.IsTrue(observation.ResultTime == null);
            Assert.IsTrue(observation.DatastreamNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations(760789)/Datastream");
            Assert.IsTrue(observation.FeatureOfInterestNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations(760789)/FeatureOfInterest");
            Assert.IsTrue(datastream.Id == "760660");
            Assert.IsTrue(foi.Id == "760746");
        }

        [Test]
        public void GetObservationCollectionTest()
        {
            // act
            var observations = client.GetObservationCollection().Result;

            // assert
            Assert.IsTrue(observations.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations?$top=100&$skip=100");
            Assert.IsTrue(observations.Items.Count == 100);
        }
    }
}
