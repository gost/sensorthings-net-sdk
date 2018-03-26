using System.Threading.Tasks;
using Newtonsoft.Json;
using SensorThings.Client;

namespace SensorThings.Core
{
    public class Datastream : AbstractEntity
    {
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

        public async Task<SensorThingsCollection<Observation>> GetObservations()
        {
            return await Http.GetJson<SensorThingsCollection<Observation>>(ObservationsNavigationLink);
        }

        public async Task<ObservedProperty> GetObservedProperty()
        {
            return await Http.GetJson<ObservedProperty>(ObservedPropertyNavigationLink);
        }

        public async Task<Sensor> GetSensor()
        {
            return await Http.GetJson<Sensor>(SensorNavigationLink);
        }

        public async Task<Thing> GetThing()
        {
            return await Http.GetJson<Thing>(ThingNavigationLink);
        }
    }
}
