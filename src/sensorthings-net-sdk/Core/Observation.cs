using Newtonsoft.Json;
using SensorThings.Client;
using System;

namespace SensorThings.Core
{
    public class Observation:AbstractEntity
    {
        public DateTime PhenomenonTime { get; set; }
        public object Result { get; set; }
        [JsonProperty("Datastream@iot.navigationLink")]
        public string DatastreamNavigationLink { get; set; }
        [JsonProperty("FeatureOfInterest@iot.navigationLink")]
        public string FeatureOfInterestNavigationLink { get; set; }
        public DateTime? ResultTime { get; set; }

        public Datastream GetDatastream()
        {
            return Http.GetJson<Datastream>(DatastreamNavigationLink);
        }

        public FeatureOfInterest GetFeatureOfInterest()
        {
            return Http.GetJson<FeatureOfInterest>(FeatureOfInterestNavigationLink);
        }
    }
}
