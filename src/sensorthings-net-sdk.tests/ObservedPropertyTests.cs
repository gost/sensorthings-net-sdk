using NUnit.Framework;
using SensorThings.Client;

namespace sensorthings_net_sdk.tests
{
    public class ObservedPropertyTests
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
        public void GetObservedPropertyTest()
        {
            // act
            var observedProperty = client.GetObservedProperty();
            var datastreams = observedProperty.GetDatastreams();

            // assert
            Assert.IsTrue(observedProperty.Id == 760803);
            Assert.IsTrue(observedProperty.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/ObservedProperties(760803)");
            Assert.IsTrue(observedProperty.Description == "acceleration of sensor");
            Assert.IsTrue(observedProperty.Name == "acceleration");
            Assert.IsTrue(observedProperty.DatastreamsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/ObservedProperties(760803)/Datastreams");
            Assert.IsTrue(datastreams.Count > 0);
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
