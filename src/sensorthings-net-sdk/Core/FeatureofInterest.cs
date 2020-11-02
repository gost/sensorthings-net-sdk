using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Newtonsoft.Json;

using SensorThings.Client;
using SensorThings.ODATA;

namespace SensorThings.Core
{
    public class FeatureOfInterest : AbstractEntity
    {
        private string _name;
        private string _description;
        private object _feature;
        private string _encodingType;
        private string _observationsNavigationLink;
        private ObservableCollection<Observation> _observations;

        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        [JsonProperty("description")]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        [JsonProperty("feature")]
        public object Feature
        {
            get => _feature;
            set => SetProperty(ref _feature, value);
        }

        [JsonProperty("encodingType")]
        public string EncodingType
        {
            get => _encodingType;
            set => SetProperty(ref _encodingType, value);
        }

        [JsonProperty("Observations@iot.navigationLink")]
        public string ObservationsNavigationLink
        {
            get => _observationsNavigationLink;
            set => SetProperty(ref _observationsNavigationLink, value);
        }

        [JsonProperty("Observations")]
        public ObservableCollection<Observation> Observations
        {
            get => _observations;
            set => SetProperty(ref _observations, value);
        }

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
