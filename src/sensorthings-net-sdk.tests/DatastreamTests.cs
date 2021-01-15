using NUnit.Framework;

using SensorThings.Client;
using SensorThings.Client.Extensions;
using SensorThings.Core;

namespace sensorthings_net_sdk.tests
{
    public class DatastreamTests
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
        public void GetDatastreamTest()
        {
            // act
            var datastream = entityHandler.GetEntity<Datastream>("760827").Result;
            var observations = datastream.GetObservations(entityHandler).Result;
            var observedProperty = datastream.GetObservedProperty(entityHandler).Result;
            var sensor = datastream.GetSensor(entityHandler).Result;
            var thing = datastream.GetThing(entityHandler).Result;


            // assert
            Assert.IsTrue(datastream.Id == "760827");
            Assert.IsTrue(datastream.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Datastreams(760827)");
            Assert.IsTrue(datastream.Description == "Data stream description");
            Assert.IsTrue(datastream.Name == "NYP_DATASTREM_4321");
            Assert.IsTrue(datastream.ObservationType == "http://www.opengis.net/def/observationType/OGC-OM/2.0/OM_Measurement");
            Assert.IsTrue(datastream.UnitOfMeasurement.Symbol == "BPM");
            Assert.IsTrue(datastream.UnitOfMeasurement.Name == "Beats Per Minute");
            Assert.IsTrue(datastream.UnitOfMeasurement.Definition == "http://www.qudt.org/qudt/owl/1.0.0/unit/Instances.html#BPM");
            Assert.IsTrue(datastream.ObservationsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Datastreams(760827)/Observations");
            Assert.IsTrue(datastream.ObservedPropertyNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Datastreams(760827)/ObservedProperty");
            Assert.IsTrue(datastream.SensorNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Datastreams(760827)/Sensor");
            Assert.IsTrue(datastream.ThingNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Datastreams(760827)/Thing");
            Assert.IsTrue(observations.Count > 0);
            Assert.IsTrue(observedProperty.Description == "acceleration of sensor");
            Assert.IsTrue(sensor.Id == "760611");
            Assert.IsTrue(thing.Id == "760737");
        }

        [Ignore("Ignore temporary because the external interface is broken, yet (Feb 2021)!")] // TODO
        public void GetDatastreamsTest()
        {
            // act
            var datastreams = entityHandler.SearchEntities<Datastream>().Result;

            // assert
            Assert.IsTrue(datastreams.Count>0);
            Assert.IsTrue(datastreams.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Datastreams?$top=100&$skip=100");
            Assert.IsTrue(datastreams.Items.Count == 100);
        }
    }
}
