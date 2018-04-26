# sensorthings-net-sdk

[![NuGet Status](http://img.shields.io/nuget/v/Geodan.SensorThings.SDK.svg?style=flat)](https://www.nuget.org/packages/Geodan.SensorThings.SDK/)
[![Build status](https://ci.appveyor.com/api/projects/status/fwnnxu7dp4ffykag?svg=true)](https://ci.appveyor.com/project/bertt/sensorthings-net-sdk)

The Geodan SensorThings .NET SDK makes it easy to add OGC SensorThings support to your .NET application.

This library is using .NET Standard 1.1

Implemented:

- HTTP GET methods

## Install

```
<<<<<<< HEAD
$ package-install Geodan.SensorThings.SDK
```

Push new version:

```
$ nuget push Geodan.SensorThings.SDK.0.2.0.nupkg -Source https://www.nuget.org/api/v2/package
=======
$ install-package Geodan.SensorThings.SDK
>>>>>>> 7528c57568dfe90e761f0fd7b7f832963e5bbb77
```

### Sample code

```c#
var server = "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/";
var client = new SensorThingsClient(server);
var datastream = client.GetDatastream(760827);
var observations = datastream.GetObservations();
var nextpage_observations = observations.GetNextPage();
var foi = observations.Items[0].GetFeatureOfInterest();
var observedProperty = datastream.GetObservedProperty();
var sensor = datastream.GetSensor();
var thing = datastream.GetThing();
var locations = thing.GetLocations();

// create observation sample:
var datastream = new Datastream();
datastream.Id = 18;
var observation = new Observation();
observation.Datastream = datastream;
observation.PhenomenonTime = DateTime.Now;
observation.Result = 100;
var returnedObservation = client.CreateObservation(observation);
```

### Sample applications

1] Console application

Description: Makes connection to SensorThings server and writes available datastreams to the console

Source: https://github.com/gost/sensorthings-net-sdk/tree/master/src/samples/ConsoleSampleApplication

2] MqttSampleApplication

Description: Consumes MQTT SensorThings messages

Source: https://github.com/gost/sensorthings-net-sdk/tree/master/src/samples/MqttSampleApplication

![alt tag](mqttsample.png)

3] RealtimeOxyPlotSampleApplication

Description: Display a realtime OxyPlot (http://www.oxyplot.org/) graph based on MQTT SensorThings messages (WPF sample)

Source: https://github.com/gost/sensorthings-net-sdk/tree/master/src/samples/RealtimeOxyPlotSampleApplication

![alt tag](realtime.png)

4] SensorThingsRealtimeLiveChartsSample

Description: Display a realtime LiveCharts (https://www.lvcharts.net/) graph based on MQTT SensorThings messages (WPF sample)


### Dependencies

.NETStandard 1.1

System.Collections (>= 4.3.0)

System.Runtime.Extensions (>= 4.3.0)

System.Resources.ResourceManager (>= 4.3.0)

System.Runtime (>= 4.3.0)

Newtonsoft.Json (>=9.0.1)

System.Net.Http: (>=4.1.0)

### Roadmap:

- HTTP POST/PUT/DELETE

- OData query support
