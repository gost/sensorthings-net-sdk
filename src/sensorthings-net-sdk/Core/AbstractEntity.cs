using Newtonsoft.Json;

namespace SensorThings.Core
{
    public abstract class AbstractEntity
    {
        [JsonProperty("@iot.id")]
        public int Id { get; set; }
        [JsonProperty("@iot.selfLink")]
        public string SelfLink { get; set; }
    }
}
