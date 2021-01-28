using NUnit.Framework;

using SensorThings.Client;
using SensorThings.Client.Extensions;
using SensorThings.Core;

namespace sensorthings_net_sdk.tests
{
    public class ObservationTests
    {
        private string server;
        private SensorThingsEntityHandler entityHandler;

        [SetUp]
        public void Initialize()
        {
            server = "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/";
            entityHandler = new SensorThingsEntityHandler(server);
        }

        [Test]
        // ReSharper disable UnusedVariable
        public void GetObservationTest()
        {
            // act
            var observation = entityHandler.GetEntity<Observation>("2706628").Result;
            var datastreamResponse = observation.GetDatastream(entityHandler).Result;
            var foiResponse = observation.GetFeatureOfInterest(entityHandler).Result;

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
            var observations = entityHandler.SearchEntities<Observation>().Result;

            // assert
            Assert.IsTrue(observations.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Observations?$top=100&$skip=100");
            Assert.IsTrue(observations.Items.Count == 100);
        }
    }
}
