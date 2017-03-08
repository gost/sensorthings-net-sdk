using Newtonsoft.Json;
using System.Collections.Generic;

namespace SensorThings.Core
{
    /**
    public class FeatureOfInterestCollection
    {
        // Todo: On scratchpad there is property @iot.count, on gost just count
        [JsonProperty("@iot.count")]
        public int Count { get; set; }
        [JsonProperty("@iot.nextLink")]
        public string NextLink { get; set; }
        [JsonProperty("value")]
        public List<FeatureOfInterest> Features { get; set; }
    }*/

    public class SensorThingsCollection<T>
    {
        // Todo: On scratchpad there is property @iot.count, on gost just count
        [JsonProperty("@iot.count")]
        public int Count { get; set; }
        [JsonProperty("@iot.nextLink")]
        public string NextLink { get; set; }
        [JsonProperty("value")]
        public List<T> Items { get; set; }
    }

}
