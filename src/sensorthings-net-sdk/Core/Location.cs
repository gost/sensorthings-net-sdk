using System.Threading.Tasks;
using Newtonsoft.Json;
using sensorthings.Core;
using sensorthings.ODATA;
using SensorThings.Client;

namespace SensorThings.Core
{
    public class Location:AbstractEntity
    {
        [JsonProperty("encodingType")]
        public string EncodingType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("location")]
        public object Feature { get; set; }

        [JsonProperty("Things@iot.navigationLink")]
        public string ThingsNavigationLink { get; set; }

        [JsonProperty("HistoricalLocations@iot.navigationLink")]
        public string HistoricalLocationsNavigationLink { get; set; }

        [JsonProperty("Things")]
        public Thing[] Things { get; set; }

        [JsonProperty("HistoricalLocations")]
        public HistoricalLocation[] HistoricalLocations { get; set; }

        public async Task<Response<SensorThingsCollection<Thing>>> GetThings(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(ThingsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<Thing>>(ThingsNavigationLink);
            }

            return await client.GetThingCollectionByLocation(Id, odata);
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>> GetHistoricalLocations(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(HistoricalLocationsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<HistoricalLocation>>(HistoricalLocationsNavigationLink);
            }

            return await client.GetHistoricalLocationsCollectionByLocation(Id, odata);
        }
    }
}
