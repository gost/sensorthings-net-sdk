using Newtonsoft.Json;
using System.Collections.Generic;

namespace SensorThings.Core.Core
{
    public class FeatureOfInterest : AbstractEntity
    {
        public FeatureOfInterest()
        {
        }

        public FeatureOfInterest(string SelfLink, string NavigationLink)
        {
            this.SelfLink = SelfLink;
            this.NavigationLink = NavigationLink;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public object Feature { get; set; }
        public List<Observation> Observations { get; set; }
        public string EncodingType { get; set; }

        [JsonProperty("Observations@iot.navigationLink")]
        public string ObservationsNavigationLink { get; set; }
    }
}
