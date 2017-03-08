using Newtonsoft.Json;

namespace SensorThings.Core
{
    public class AbstractEntity
    {

        public AbstractEntity()
        {
        }

        [JsonProperty("@iot.id")]
        public int Id { get; set; }
        [JsonProperty("@iot.selfLink")]
        public string SelfLink { get; set; }
    }
}
