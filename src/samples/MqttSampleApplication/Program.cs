using Newtonsoft.Json;
using SensorThings.Core;
using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttSampleApplication
{
    class Program
    {
        /**
         * This sample is using Paho MQTT library to connect with SensorThings (datastream 17)
         * Publish an observation using something like:
         * curl -X POST -H "Accept: application/json" -H "Content-Type: application/json" -d '{
                    "phenomenonTime": "2016-05-09T11:04:15.790Z",
                    "resultTime" : "2016-05-09T11:04:15.790Z",
                    "result" : 38,
                    "Datastream":{"@iot.id":17}
            }' "http://gost.geodan.nl/v1.0/Observations"
            In the client_MqttMsgPublishReceived event the JSON response is converted to am Observation object
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Sample of MQTT and SensorThings SDK");
            var client = new MqttClient("gost.geodan.nl");
            byte code = client.Connect(Guid.NewGuid().ToString());

            ushort msgId = client.Subscribe(new string[] { "Datastreams(17)/Observations" },
                    new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE});
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
        }

        private static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var str = Encoding.Default.GetString(e.Message);
            var observation = JsonConvert.DeserializeObject<Observation>(str);
            // example: navigate to other entities (Things, Datastreams)
            var datastream = observation.GetDatastream();
            Console.WriteLine("Datastream: " + datastream.Id); 
            Console.WriteLine("New Observation published: " + observation.Result);
        }
    }
}
