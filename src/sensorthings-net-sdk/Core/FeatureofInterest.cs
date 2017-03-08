using Newtonsoft.Json;

namespace SensorThings.Core
{
    public class FeatureOfInterest : AbstractEntity
    {
        public FeatureOfInterest()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public object Feature { get; set; }
        public string EncodingType { get; set; }
        [JsonProperty("Observations@iot.navigationLink")]
        public string ObservationsNavigationLink { get; set; }
    }
}
