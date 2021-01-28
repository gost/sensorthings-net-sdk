using NUnit.Framework;
using SensorThings.Client;
using SensorThings.Client.Extensions;
using SensorThings.Core;

namespace sensorthings_net_sdk.tests
{
    public class ObservedPropertyTests
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
        public void GetObservedPropertyTest()
        {
            // act
            var observedProperty = entityHandler.GetEntity<ObservedProperty>("1893289").Result;
            var datastreams = observedProperty.GetDatastreams(entityHandler).Result;

            // assert
            Assert.IsFalse(string.IsNullOrEmpty(observedProperty.Id));
        }

        [Test]
        public void GetObservedPropertyCollectionTest()
        {
            // act
            var observedProperties = entityHandler.SearchEntities<ObservedProperty>().Result;

            // assert
            Assert.IsTrue(observedProperties.Count>0);
            Assert.IsTrue(observedProperties.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/ObservedProperties?$top=100&$skip=100");
            Assert.IsTrue(observedProperties.Items.Count == 100);
        }
    }
}
