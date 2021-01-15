using NUnit.Framework;
using SensorThings.Client;
using SensorThings.Client.Extensions;
using SensorThings.Core;

namespace sensorthings_net_sdk.tests
{
    public class FeatureOfInterestTests
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
        public void GetFeatureOfInterestTest()
        {
            // act
            var foi = entityHandler.GetEntity<FeatureOfInterest>("1840970").Result;
            var observations = foi.GetObservations(entityHandler).Result;

            // assert
            Assert.IsFalse(string.IsNullOrEmpty(foi.Id));
            // todo: How to parse the GeoJSON returned?
            // Assert.IsTrue(foi.Feature.ToString() == @"{{"coordinates": [103.84844899177551,1.3790908801131481],"type": "Point"}}");
            Assert.IsTrue(observations.Count >= 0);
        }

        [Test]
        public void GetFeatureOfInterestCollectionTest()
        {
            // act
            var fois = entityHandler.SearchEntities<FeatureOfInterest>().Result;

            // assert
            Assert.IsTrue(fois.Count > 0);
            Assert.IsTrue(fois.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/FeaturesOfInterest?$top=100&$skip=100");
            Assert.IsTrue(fois.Items.Count == 100);
        }
    }
}
