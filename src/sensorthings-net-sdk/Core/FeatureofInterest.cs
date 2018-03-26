using System.Threading.Tasks;
using Newtonsoft.Json;
using SensorThings.Client;

namespace SensorThings.Core
{
    public class FeatureOfInterest : AbstractEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public object Feature { get; set; }
        public string EncodingType { get; set; }
        [JsonProperty("Observations@iot.navigationLink")]
        public string ObservationsNavigationLink { get; set; }

        public async Task<SensorThingsCollection<Observation>> GetObservations()
        {
            return await Http.GetJson<SensorThingsCollection<Observation>>(ObservationsNavigationLink);
        }
    }
}
