using NUnit.Framework;
using SensorThings.Client;

namespace sensorthings_net_sdk.tests
{
    public class SensorTests
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
        public void GetSensorTest()
        {
            // act
            var sensor = client.GetSensor(760645);
            var datastreams = sensor.GetDatastreams();

            // assert
            Assert.IsTrue(sensor.Id == 760645);
            Assert.IsTrue(sensor.SelfLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Sensors(760645)");
            Assert.IsTrue(sensor.Description == "SHT3x-DIS is the next generation of Sensirion’s temperature and humidity sensors. I");
            Assert.IsTrue(sensor.Name == "SHT31_XX2");
            Assert.IsTrue(sensor.EncodingType == "application/pdf");
            Assert.IsTrue(sensor.Metadata == "http://cdn.sparkfun.com/datasheets/Sensors/Weather/RHT03.pdf");
            Assert.IsTrue(sensor.DatastreamsNavigationLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Sensors(760645)/Datastreams");
            Assert.IsTrue(datastreams.Count > 0);

        }

        [Test]
        public void GetSensorsTest()
        {
            // act
            var sensors = client.GetSensorCollection();

            // assert
            Assert.IsTrue(sensors.Count == 1065);
            Assert.IsTrue(sensors.NextLink == "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/Sensors?$top=100&$skip=100");
            Assert.IsTrue(sensors.Items.Count == 100);
            Assert.IsTrue(sensors.Items[0].Id == 760645);
        }
    }
}
