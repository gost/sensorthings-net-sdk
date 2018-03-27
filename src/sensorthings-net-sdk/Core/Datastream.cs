using System.Threading.Tasks;
using Newtonsoft.Json;
using sensorthings.Core;
using sensorthings.ODATA;
using SensorThings.Client;

namespace SensorThings.Core
{
    public class Datastream : AbstractEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("observationType")]
        public string ObservationType { get; set; }

        [JsonProperty("unitOfMeasurement")]
        public UnitOfMeasurement UnitOfMeasurement {get;set;}

        [JsonProperty("Observations@iot.navigationLink")]
        public string ObservationsNavigationLink { get; set; }

        [JsonProperty("ObservedProperty@iot.navigationLink")]
        public string ObservedPropertyNavigationLink { get; set; }

        [JsonProperty("Sensor@iot.navigationLink")]
        public string SensorNavigationLink { get; set; }

        [JsonProperty("Thing@iot.navigationLink")]
        public string ThingNavigationLink { get; set; }

        [JsonProperty("Thing")]
        public Thing Thing { get; set; }

        [JsonProperty("Sensor")]
        public Sensor Sensor { get; set; }

        [JsonProperty("Observations")]
        public Observation[] Observations{ get; set; }

        [JsonProperty("ObservedProperty")]
        public ObservedProperty ObservedProperty { get; set; }        

        public async Task<Response<SensorThingsCollection<Observation>>> GetObservations(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(ObservationsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<Observation>> (ObservationsNavigationLink);
            }

            return await client.GetObservationCollectionByDatastream(Id, odata);
        }

        public async Task<Response<ObservedProperty>> GetObservedProperty(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(ObservedPropertyNavigationLink))
            {
                return await Http.GetJson<ObservedProperty>(ObservedPropertyNavigationLink);
            }

            return await client.GetObservedPropertyByDatastream(Id, odata);
        }

        public async Task<Response<Sensor>> GetSensor(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(SensorNavigationLink))
            {
                return await Http.GetJson<Sensor>(SensorNavigationLink);
            }

            return await client.GetSensorByDatastream(Id, odata);
        }

        public async Task<Response<Thing>> GetThing(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(ThingNavigationLink))
            {
                return await Http.GetJson<Thing>(ThingNavigationLink);
            }

            return await client.GetThingByDatastream(Id, odata);
        }
    }
}
