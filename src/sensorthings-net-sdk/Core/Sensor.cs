using System.Threading.Tasks;
using Newtonsoft.Json;
using SensorThings.Client;

namespace SensorThings.Core
{
    public class Sensor:AbstractEntity
    {
        [JsonProperty("Datastreams@iot.navigationLink")]
        public string DatastreamsNavigationLink { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        // todo: is metadata of type string?
        public string Metadata { get; set; }
        public string EncodingType { get; set; }

        public async Task<SensorThingsCollection<Datastream>> GetDatastreams()
        {
            return await Http.GetJson<SensorThingsCollection<Datastream>>(DatastreamsNavigationLink);
        }
    }
}
