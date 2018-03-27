using System.Threading.Tasks;
using Newtonsoft.Json;
using sensorthings.Core;
using sensorthings.ODATA;
using SensorThings.Client;

namespace SensorThings.Core
{
    public class Sensor:AbstractEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("metadata")]
        public string Metadata { get; set; }

        [JsonProperty("encodingType")]
        public string EncodingType { get; set; }

        [JsonProperty("Datastreams@iot.navigationLink")]
        public string DatastreamsNavigationLink { get; set; }

        [JsonProperty("Datastreams")]
        public Datastream[] Datastreams{ get; set; }

        public async Task<Response<SensorThingsCollection<Datastream>>> GetDatastreams(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(DatastreamsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<Datastream>>(DatastreamsNavigationLink);
            }

            return await client.GetDatastreamCollectionBySensor(Id, odata);
        }
    }
}
