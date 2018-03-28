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
            var response = client.GetObservation("760789").Result;
            var observation = response.Result;

            var datastreamResponse = observation.GetDatastream(client).Result;
            var datastream = datastreamResponse.Result;

            var foiResponse = observation.GetFeatureOfInterest(client).Result;
            var foi = foiResponse.Result;

            // assert
            Assert.IsTrue(observation.Id == "760789");
            Assert.IsTrue(observation.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations(760789)");
            // Phenomenon time should be 2020-01-25T19:00:00.000Z in Iso8601
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
            var response = client.GetObservationCollection().Result;
            var observations = response.Result;

            // assert
            Assert.IsTrue(observations.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations?$top=100&$skip=100");
            Assert.IsTrue(observations.Items.Count == 100);
        }
    }
}
