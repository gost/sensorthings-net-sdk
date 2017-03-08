using NUnit.Framework;
using SensorThings.Client;
namespace sensorthings_net_sdk.tests
{
    public class SensorThingsClientTests
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
            var foi = client.GetFeatureOfInterest();

            // assert
            Assert.IsTrue(foi.Id == 760921);
            Assert.IsTrue(foi.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/FeaturesOfInterest(760921)");
            Assert.IsTrue(foi.Description == "Generated using location details: Nanyang Polytechnic Block S");
            Assert.IsTrue(foi.Name == "Nanyang Polytechnic");
            // todo: How to parse the GeoJSON returned?
            // Assert.IsTrue(foi.Feature.ToString() == @"{{"coordinates": [103.84844899177551,1.3790908801131481],"type": "Point"}}");
            Assert.IsTrue(foi.ObservationsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/FeaturesOfInterest(760921)/Observations");
        }

        [Test]
        public void GetFeatureOfInterestCollectionTest()
        {
            // act
            var fois = client.GetFeatureOfInterestCollection();

            // assert
            Assert.IsTrue(fois.Count == 367);
            Assert.IsTrue(fois.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/FeaturesOfInterest?$top=100&$skip=100");
            Assert.IsTrue(fois.Items.Count == 100);
        }

        [Test]
        public void GetObservedPropertyTest()
        {
            // act
            var observedProperty = client.GetObservedProperty();

            // assert
            Assert.IsTrue(observedProperty.Id == 760803);
            Assert.IsTrue(observedProperty.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/ObservedProperties(760803)");
            Assert.IsTrue(observedProperty.Description == "acceleration of sensor");
            Assert.IsTrue(observedProperty.Name == "acceleration");
            Assert.IsTrue(observedProperty.DatastreamsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/ObservedProperties(760803)/Datastreams");
        }

        [Test]
        public void GetObservedPropertyCollectionTest()
        {
            // act
            var observedProperties = client.GetObservedPropertyCollection();

            // assert
            Assert.IsTrue(observedProperties.Count == 1162);
            Assert.IsTrue(observedProperties.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/ObservedProperties?$top=100&$skip=100");
            Assert.IsTrue(observedProperties.Items.Count == 100);
            Assert.IsTrue(observedProperties.Items[0].Id == 760803);
        }


    }
}
