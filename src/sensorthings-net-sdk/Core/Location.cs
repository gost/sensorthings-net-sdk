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

        public SensorThingsCollection<Thing> GetThings()
        {
            return Http.GetJson<SensorThingsCollection<Thing>>(ThingsNavigationLink);
        }

        public SensorThingsCollection<HistoricalLocation> GetHistoricalLocations()
        {
            return Http.GetJson<SensorThingsCollection<HistoricalLocation>>(HistoricalLocationsNavigationLink);
        }
    }
}
