using NUnit.Framework;
using SensorThings.Client;
using SensorThings.Client.Extensions;
using SensorThings.Core;

namespace sensorthings_net_sdk.tests
{
    public class SensorTests
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
        public void GetSensorTest()
        {
            // act
            var sensor = entityHandler.GetEntity<Sensor>("760645").Result;
            var datastreams = sensor.GetDatastreams(entityHandler).Result;

            // assert
            Assert.IsTrue(sensor.Id == "760645");
            Assert.IsTrue(sensor.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Sensors(760645)");
            Assert.IsTrue(sensor.Description == "SHT3x-DIS is the next generation of Sensirion’s temperature and humidity sensors. I");
            Assert.IsTrue(sensor.Name == "SHT31_XX2");
            Assert.IsTrue(sensor.EncodingType == "application/pdf");
            Assert.IsTrue(sensor.Metadata.ToString() == "http://cdn.sparkfun.com/datasheets/Sensors/Weather/RHT03.pdf");
            Assert.IsTrue(sensor.DatastreamsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Sensors(760645)/Datastreams");
            Assert.IsTrue(datastreams.Count > 0);

        }

        [Test]
        public void GetSensorsTest()
        {
            // act
            var sensors = entityHandler.SearchEntities<Sensor>().Result;

            // assert
            Assert.IsTrue(sensors.Count > 0);
            Assert.IsTrue(sensors.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Sensors?$top=100&$skip=100");
            Assert.IsTrue(sensors.Items.Count == 100);
        }
    }
}
