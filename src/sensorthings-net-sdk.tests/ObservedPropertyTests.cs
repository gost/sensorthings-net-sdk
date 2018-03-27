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
            var response = client.GetObservedProperty("1893289").Result;
            var observedProperty = response.Result;

            var datastreamsResponse = observedProperty.GetDatastreams(client).Result;
            var datastreams = datastreamsResponse.Result;

            // assert
            Assert.IsFalse(string.IsNullOrEmpty(observedProperty.Id));
        }

        [Test]
        public void GetObservedPropertyCollectionTest()
        {
            // act
            var response = client.GetObservedPropertyCollection().Result;
            var observedProperties = response.Result;

            // assert
            Assert.IsTrue(observedProperties.Count>0);
            Assert.IsTrue(observedProperties.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/ObservedProperties?$top=100&$skip=100");
            Assert.IsTrue(observedProperties.Items.Count == 100);
        }
    }
}
