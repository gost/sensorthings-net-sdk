using Newtonsoft.Json;
using SensorThings.Client;

namespace SensorThings.Core
{
    public class Datastream : AbstractEntity
    {
        public Datastream()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ObservationType { get; set; }
        public UnitOfMeasurement UnitOfMeasurement {get;set;}
        [JsonProperty("Observations@iot.navigationLink")]
        public string ObservationsNavigationLink { get; set; }
        [JsonProperty("ObservedProperty@iot.navigationLink")]
        public string ObservedPropertyNavigationLink { get; set; }
        [JsonProperty("Sensor@iot.navigationLink")]
        public string SensorNavigationLink { get; set; }
        [JsonProperty("Thing@iot.navigationLink")]
        public string ThingNavigationLink { get; set; }

        public SensorThingsCollection<Observation> GetObservations()
        {
            return Http.GetJson<SensorThingsCollection<Observation>>(ObservationsNavigationLink);
        }

        public ObservedProperty GetObservedProperty()
        {
            return Http.GetJson<ObservedProperty>(ObservedPropertyNavigationLink);
        }

        public Sensor GetSensor()
        {
            return Http.GetJson<Sensor>(SensorNavigationLink);
        }

        public Thing GetThing()
        {
            return Http.GetJson<Thing>(ThingNavigationLink);
        }
    }
}
