using System.Threading.Tasks;
using Newtonsoft.Json;
using sensorthings.Core;
using sensorthings.ODATA;
using SensorThings.Client;

namespace SensorThings.Core
{
    public class ObservedProperty:AbstractEntity
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("definition")]
        public string Definition { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Datastreams@iot.navigationLink")]
        public string DatastreamsNavigationLink { get; set; }

        [JsonProperty("Datastreams")]
        public Datastream[] Datastreams { get; set; }

        public async Task<Response<SensorThingsCollection<Datastream>>> GetDatastreams(SensorThingsClient client, OdataQuery odata = null)
        {
            return await client.GetDatastreamCollectionByObservedProperty(Id, odata);
        }
    }
}
