# sensorthings-net-sdk

The Geodan SensorThings .NET SDK makes it easy to add OGC SensorThings support to your .NET application.

This library is using .NET Standard 1.1

Implemented:

- HTTP GET methods

Sample code:

```
var server = "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/";
var client = new SensorThingsClient(server);
var datastream = client.GetDatastream(760827);
var observations = datastream.GetObservations();
var observedProperty = datastream.GetObservedProperty();
var sensor = datastream.GetSensor();
var thing = datastream.GetThing();

```

Roadmap:

- HTTP POST/PUT/DELETE

- MQTT support

- NuGet support

- Sample apps (console, IOS, Android)
