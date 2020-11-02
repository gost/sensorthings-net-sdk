using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Newtonsoft.Json;

using SensorThings.Client;
using SensorThings.ODATA;

namespace SensorThings.Core
{
    public class Location : AbstractEntity
    {
        private string _encodingType;
        private string _name;
        private string _description;
        private object _feature;
        private string _thingsNavigationLink;
        private string _historicalLocationsNavigationLink;
        private ObservableCollection<Thing> _things;
        private ObservableCollection<HistoricalLocation> _historicalLocations;

        [JsonProperty("encodingType")]
        public string EncodingType
        {
            get => _encodingType;
            set => SetProperty(ref _encodingType, value);
        }

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

        [JsonProperty("location")]
        public object Feature
        {
            get => _feature;
            set => SetProperty(ref _feature, value);
        }

        [JsonProperty("Things@iot.navigationLink")]
        public string ThingsNavigationLink
        {
            get => _thingsNavigationLink;
            set => SetProperty(ref _thingsNavigationLink, value);
        }

        [JsonProperty("HistoricalLocations@iot.navigationLink")]
        public string HistoricalLocationsNavigationLink
        {
            get => _historicalLocationsNavigationLink;
            set => SetProperty(ref _historicalLocationsNavigationLink, value);
        }

        [JsonProperty("Things")]
        public ObservableCollection<Thing> Things
        {
            get => _things;
            set => SetProperty(ref _things, value);
        }

        [JsonProperty("HistoricalLocations")]
        public ObservableCollection<HistoricalLocation> HistoricalLocations
        {
            get => _historicalLocations;
            set => SetProperty(ref _historicalLocations, value);
        }

        public async Task<Response<SensorThingsCollection<Thing>>> GetThings(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(ThingsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<Thing>>(ThingsNavigationLink);
            }

            return await client.GetThingCollectionByLocation(Id, odata);
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>> GetHistoricalLocations(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(HistoricalLocationsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<HistoricalLocation>>(HistoricalLocationsNavigationLink);
            }

            return await client.GetHistoricalLocationsCollectionByLocation(Id, odata);
        }
    }
}
