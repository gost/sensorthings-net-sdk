using Newtonsoft.Json;
using SensorThings.Client;
using System;
using System.Threading.Tasks;

namespace SensorThings.Core
{
    public class Observation:AbstractEntity
    {
        public DateTime? PhenomenonTime { get; set; }
        public object Result { get; set; }
        [JsonProperty("Datastream@iot.navigationLink")]
        public string DatastreamNavigationLink { get; set; }
        [JsonProperty("FeatureOfInterest@iot.navigationLink")]
        public string FeatureOfInterestNavigationLink { get; set; }
        public DateTime? ResultTime { get; set; }

        public async Task<Datastream> GetDatastream()
        {
            return await Http.GetJson<Datastream>(DatastreamNavigationLink);
        }

        public async Task<FeatureOfInterest> GetFeatureOfInterest()
        {
            return await Http.GetJson<FeatureOfInterest>(FeatureOfInterestNavigationLink);
        }

        // [JsonIgnore]
        public Datastream Datastream { get; set; }
    }
}
