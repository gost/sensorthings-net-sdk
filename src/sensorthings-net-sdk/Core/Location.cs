using System.Threading.Tasks;
using Newtonsoft.Json;
using SensorThings.Client;

namespace SensorThings.Core
{
    public class Location:AbstractEntity
    {
        public string EncodingType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonProperty("location")]
        public object Feature { get; set; }
        [JsonProperty("Things@iot.navigationLink")]
        public string ThingsNavigationLink { get; set; }
        [JsonProperty("HistoricalLocations@iot.navigationLink")]
        public string HistoricalLocationsNavigationLink { get; set; }

        public async Task<SensorThingsCollection<Thing>> GetThings()
        {
            return await Http.GetJson<SensorThingsCollection<Thing>>(ThingsNavigationLink);
        }

        public async Task<SensorThingsCollection<HistoricalLocation>> GetHistoricalLocations()
        {
            return await Http.GetJson<SensorThingsCollection<HistoricalLocation>>(HistoricalLocationsNavigationLink);
        }
    }
}
