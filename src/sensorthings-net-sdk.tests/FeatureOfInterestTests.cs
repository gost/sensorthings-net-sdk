using NUnit.Framework;
using SensorThings.Client;

namespace sensorthings_net_sdk.tests
{
    public class FeatureOfInterestTests
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
        public void GetFeatureOfInterestTest()
        {
            // act
            var response = client.GetFeatureOfInterest("1840970").Result;
            var foi = response.Result;

            var observationsResponse = foi.GetObservations(client).Result;
            var observations = observationsResponse.Result;

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
            var response = client.GetFeatureOfInterestCollection().Result;
            var fois = response.Result;

            // assert
            Assert.IsTrue(fois.Count > 0);
            Assert.IsTrue(fois.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/FeaturesOfInterest?$top=100&$skip=100");
            Assert.IsTrue(fois.Items.Count == 100);
        }
    }
}
