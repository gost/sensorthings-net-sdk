using Newtonsoft.Json;
using SensorThings.Client;
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

        public SensorThingsCollection<Location> GetLocations()
        {
            return Http.GetJson<SensorThingsCollection<Location>>(LocationsNavigationLink);
        }

        public Thing GetThing()
        {
            return Http.GetJson<Thing>(ThingNavigationLink);
        }

    }
}
