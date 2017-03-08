using NUnit.Framework;
using SensorThings.Client;
namespace sensorthings_net_sdk.tests
{
    public class SensorThingsClientTests
    {
        [Test]
        public void InitializeTest()
        {
            // arrange 
            var server = "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/";

            // act
            var client = new SensorThingsClient(server);
            var foi = client.GetFeatureOfInterest();

            // assert
            Assert.IsTrue(client.Server == server);
            Assert.IsTrue(foi.Id == 760921);
            Assert.IsTrue(foi.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/FeaturesOfInterest(760921)");
            Assert.IsTrue(foi.Description == "Generated using location details: Nanyang Polytechnic Block S");
            Assert.IsTrue(foi.Name == "Nanyang Polytechnic");
            // todo: How to parse the GeoJSON returned?
            // Assert.IsTrue(foi.Feature.ToString() == @"{{"coordinates": [103.84844899177551,1.3790908801131481],"type": "Point"}}");
            Assert.IsTrue(foi.ObservationsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/FeaturesOfInterest(760921)/Observations");
        }
    }
}
