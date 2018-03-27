using Newtonsoft.Json;

namespace SensorThings.Core
{
    public class UnitOfMeasurement
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("definition")]
        public string Definition { get; set; }
    }
}
