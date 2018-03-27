using System.Threading.Tasks;
using Newtonsoft.Json;
using sensorthings.Core;
using sensorthings.ODATA;
using SensorThings.Client;

namespace SensorThings.Core
{
    public class FeatureOfInterest : AbstractEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("feature")]
        public object Feature { get; set; }

        [JsonProperty("encodingType")]
        public string EncodingType { get; set; }

        [JsonProperty("Observations@iot.navigationLink")]
        public string ObservationsNavigationLink { get; set; }

        [JsonProperty("Observations")]
        public Observation[] Observations{ get; set; }

        public async Task<Response<SensorThingsCollection<Observation>>> GetObservations(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(ObservationsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<Observation>>(ObservationsNavigationLink);
            }

            return await client.GetObservationCollectionByFeatureOfInterest(Id, odata);
        }
    }
}
