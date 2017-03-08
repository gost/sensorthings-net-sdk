using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SensorThings.Core
{
    public class HistoricalLocation: AbstractEntity
    {
        public HistoricalLocation()
        {
        }

        public DateTime Time { get; set; }
        public Thing Thing { get; set; }
        public List<Location> Locations { get; set; }
        [JsonProperty("Locations@iot.navigationLink")]
        public string LocationsNavigationLink { get; set; }
        [JsonProperty("Thing@iot.navigationLink")]
        public string ThingNavigationLink { get; set; }
    }
}
