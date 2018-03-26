using Newtonsoft.Json;
using SensorThings.Client;
using System;
using System.Threading.Tasks;

namespace SensorThings.Core
{
    public class HistoricalLocation: AbstractEntity
    {
        public DateTime Time { get; set; }
        [JsonProperty("Locations@iot.navigationLink")]
        public string LocationsNavigationLink { get; set; }
        [JsonProperty("Thing@iot.navigationLink")]
        public string ThingNavigationLink { get; set; }

        public async Task<SensorThingsCollection<Location>> GetLocations()
        {
            return await Http.GetJson<SensorThingsCollection<Location>>(LocationsNavigationLink);
        }

        public async Task<Thing> GetThing()
        {
            return await Http.GetJson<Thing>(ThingNavigationLink);
        }

    }
}
