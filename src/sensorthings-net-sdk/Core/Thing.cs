using Newtonsoft.Json;
using System.Collections.Generic;

namespace SensorThings.Core
{
    public class Thing: AbstractEntity
    {
        public Thing()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string,object> Properties { get; set; }
        [JsonProperty("Datastreams@iot.navigationLink")]
        public string DatastreamsNavigationLink { get; set; }
        [JsonProperty("HistoricalLocations@iot.navigationLink")]
        public string HistoricalLocationsNavigationLink { get; set; }
        [JsonProperty("Locations@iot.navigationLink")]
        public string LocationsNavigationLink { get; set; }
    }
}
