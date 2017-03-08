using Newtonsoft.Json;
using System;

namespace SensorThings.Core
{
    public class HistoricalLocation: AbstractEntity
    {
        public HistoricalLocation()
        {
        }

        public DateTime Time { get; set; }
        [JsonProperty("Locations@iot.navigationLink")]
        public string LocationsNavigationLink { get; set; }
        [JsonProperty("Thing@iot.navigationLink")]
        public string ThingNavigationLink { get; set; }
    }
}
