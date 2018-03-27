using Newtonsoft.Json;
using SensorThings.Client;
using System;
using System.Threading.Tasks;
using sensorthings.Core;
using sensorthings.ODATA;

namespace SensorThings.Core
{
    public class Observation:AbstractEntity
    {
        [JsonProperty("phenomenonTime")]
        public DateTime? PhenomenonTime { get; set; }

        [JsonProperty("result")]
        public object Result { get; set; }

        [JsonProperty("Datastream@iot.navigationLink")]
        public string DatastreamNavigationLink { get; set; }

        [JsonProperty("FeatureOfInterest@iot.navigationLink")]
        public string FeatureOfInterestNavigationLink { get; set; }

        [JsonProperty("resultTime")]
        public DateTime? ResultTime { get; set; }

        [JsonProperty("Datastream")]
        public Datastream Datastream { get; set; }

        [JsonProperty("FeatureOfInterest")]
        public FeatureOfInterest FeatureOfInterest { get; set; }

        public async Task<Response<Datastream>> GetDatastream(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(DatastreamNavigationLink))
            {
                return await Http.GetJson<Datastream>(DatastreamNavigationLink);
            }

            return await client.GetDatastreamByObservation(Id, odata);
        }

        public async Task<Response<FeatureOfInterest>> GetFeatureOfInterest(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(FeatureOfInterestNavigationLink))
            {
                return await Http.GetJson<FeatureOfInterest>(FeatureOfInterestNavigationLink);
            }

            return await client.GetFeatureOfInterestByObservation(Id, odata);
        }
    }
}
