using Newtonsoft.Json;
using System.Collections.Generic;

namespace SensorThings.Core
{
    public class Location:AbstractEntity
    {
        public Location() { }

        public List<Thing> Things { get; set; }
        public string EncodingType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonProperty("location")]
        public object Feature { get; set; }
        [JsonProperty("Things@iot.navigationLink")]
        public string ThingsNavigationLink { get; set; }
        [JsonProperty("HistoricalLocations@iot.navigationLink")]
        public string HistoricalLocationsNavigationLink { get; set; }

    }
}
