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

        public SensorThingsCollection<Datastream> GetDatastreams()
        {
            return Http.GetJson<SensorThingsCollection<Datastream>>(DatastreamsNavigationLink);
        }
    }
}
