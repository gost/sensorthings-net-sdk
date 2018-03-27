using Newtonsoft.Json;
using SensorThings.Client;
using System;
using System.Threading.Tasks;
using sensorthings.Core;
using sensorthings.ODATA;

namespace SensorThings.Core
{
    public class HistoricalLocation: AbstractEntity
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("Locations@iot.navigationLink")]
        public string LocationsNavigationLink { get; set; }

        [JsonProperty("Thing@iot.navigationLink")]
        public string ThingNavigationLink { get; set; }

        [JsonProperty("Locations")]
        public Location[] Locations { get; set; }

        [JsonProperty("Thing")]
        public Thing Thing { get; set; }

        public async Task<Response<SensorThingsCollection<Location>>> GetLocations(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(LocationsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<Location>>(LocationsNavigationLink);
            }

            return await client.GetLocationCollectionByHistoricalLocation(Id, odata);
        }

        public async Task<Response<Thing>> GetThing(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(ThingNavigationLink))
            {
                return await Http.GetJson<Thing>(ThingNavigationLink);
            }

            return await client.GetThingByHistoricalLocation(Id, odata);
        }

    }
}
