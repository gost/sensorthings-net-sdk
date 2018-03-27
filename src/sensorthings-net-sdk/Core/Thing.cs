using Newtonsoft.Json;
using SensorThings.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using sensorthings.Core;
using sensorthings.ODATA;

namespace SensorThings.Core
{
    public class Thing : AbstractEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("properties")]
        public Dictionary<string,object> Properties { get; set; }

        [JsonProperty("Datastreams@iot.navigationLink")]
        public string DatastreamsNavigationLink { get; set; }

        [JsonProperty("HistoricalLocations@iot.navigationLink")]
        public string HistoricalLocationsNavigationLink { get; set; }

        [JsonProperty("Locations@iot.navigationLink")]
        public string LocationsNavigationLink { get; set; }

        [JsonProperty("Datastreams")]
        public Datastream[] Datastreams { get; set; }

        [JsonProperty("HistoricalLocations")]
        public HistoricalLocation[] HistoricalLocations { get; set; }

        [JsonProperty("Locations")]
        public Location[] Locations { get; set; }

        public async Task<Response<SensorThingsCollection<Datastream>>> GetDatastreams(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(DatastreamsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<Datastream>>(DatastreamsNavigationLink);
            }

            return await client.GetDatastreamCollectionByThing(Id, odata);
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>> GetHistoricalLocations(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(HistoricalLocationsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<HistoricalLocation>>(HistoricalLocationsNavigationLink);
            }

            return await client.GetHistoricalLocationsCollectionByThing(Id, odata);
        }

        public async Task<Response<SensorThingsCollection<Location>>> GetLocations(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(LocationsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<Location>>(LocationsNavigationLink);
            }

            return await client.GetLocationCollectionByThing(Id, odata);
        }
    }
}
