using Newtonsoft.Json;
using SensorThings.Client;
using SensorThings.Core;
using System;
using System.Linq;
using System.Net;
using System.Text;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

/**
 * This sample does the following in Unity3D:
 * 
 * - Connect to a SensorThings server with specified datastream
 * - Get the latest observation for the given datastream using HTTP
 * - Get observation updates using MQTT protocol
 *  -Display the current observation value in Unity3D TextMesh
 *  
 *  Dependencies:
 *  - MQTT library (Paho https://github.com/eclipse/paho.mqtt.m2mqtt, .NET Standard)
 *  - SensorThings client library (https://github.com/gost/sensorthings-net-sdk , .NET Standard 1.1) 
 */
public class SensorThingsObservationDisplay : MonoBehaviour
{
    private string lastObservation;
    private GameObject go;
    //var server = "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/";
    public string server = "https://gost.geodan.nl/v1.0";
    public int datastream = 11;

    void Start()
    {
        if (server.Contains("https"))
        {
            //trust the certificate...
            ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => { return true; };
        }

        var client = new SensorThingsClient(server);
        var ds = client.GetDatastream(datastream);
        lastObservation = ds.GetObservations().Items.First().Result.ToString();
        // todo: do something with the location...
        // var dsLocation = ds.GetThing().GetLocations().Items.First();
        Debug.Log("Last observation: " + lastObservation);

        var mqttclient = new MqttClient(new Uri(server).Host);
        mqttclient.Connect(Guid.NewGuid().ToString());

        mqttclient.Subscribe(new string[] { $"Datastreams({datastream})/Observations" },
                new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        mqttclient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

        go = new GameObject();
        var tr = go.GetComponent<Transform>();
        var p = new Vector3(0,0,0);
        var q = new Quaternion(0, 0, 0, 0);
        tr.SetPositionAndRotation(p,q);
        var myText = go.AddComponent<TextMesh>();
        myText.name = "temperature";
        myText.fontSize = 50;
        myText.anchor = TextAnchor.LowerCenter;
        myText.text = lastObservation;
    }

    private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        try
        {
            var str = Encoding.Default.GetString(e.Message);
            lastObservation = JsonConvert.DeserializeObject<Observation>(str).Result.ToString();
        }
        catch (Exception ex)
        {
            Debug.Log("Exception: " + ex.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (go != null)
        {
            go.GetComponent<TextMesh>().text = lastObservation;
        }
    }
}
