using Newtonsoft.Json;

namespace SensorThings.Core
{
    public class ObservedProperty:AbstractEntity
    {
        public string Description { get; set; }
        public string Definition { get; set; }
        public string Name { get; set; }
        [JsonProperty("Datastreams@iot.navigationLink")]
        public string DatastreamsNavigationLink { get; set; }
    }
}
