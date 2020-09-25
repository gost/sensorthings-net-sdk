using Newtonsoft.Json;
using SensorThings.Client;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using sensorthings.Core;
using sensorthings.ODATA;

namespace SensorThings.Core
{
    public class Thing : AbstractEntity
    {
        private string _name;
        private string _description;
        private IDictionary<string, object> _properties;
        private string _datastreamsNavigationLink;
        private string _historicalLocationNavigationLink;
        private string _locationsNavigationLink;
        private ObservableCollection<Datastream> _datastreams;
        private ObservableCollection<Location> _locations;
        private ObservableCollection<HistoricalLocation> _historicalLocations;

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

        [JsonProperty("properties")]
        public IDictionary<string, object> Properties
        {
            get => _properties;
            set => SetProperty(ref _properties, value);
        }

        [JsonProperty("Datastreams@iot.navigationLink")]
        public string DatastreamsNavigationLink
        {
            get => _datastreamsNavigationLink;
            set => SetProperty(ref _datastreamsNavigationLink, value);
        }

        [JsonProperty("HistoricalLocations@iot.navigationLink")]
        public string HistoricalLocationsNavigationLink
        {
            get => _historicalLocationNavigationLink;
            set => SetProperty(ref _historicalLocationNavigationLink, value);
        }

        [JsonProperty("Locations@iot.navigationLink")]
        public string LocationsNavigationLink
        {
            get => _locationsNavigationLink;
            set => SetProperty(ref _locationsNavigationLink, value);
        }

        [JsonProperty("Datastreams")]
        public ObservableCollection<Datastream> Datastreams
        {
            get => _datastreams;
            set => SetProperty(ref _datastreams, value);
        }

        [JsonProperty("HistoricalLocations")]
        public ObservableCollection<HistoricalLocation> HistoricalLocations
        {
            get => _historicalLocations;
            set => SetProperty(ref _historicalLocations, value);
        }

        [JsonProperty("Locations")]
        public ObservableCollection<Location> Locations
        {
            get => _locations;
            set => SetProperty(ref _locations, value);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>> GetDatastreams(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(DatastreamsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<Datastream>>(DatastreamsNavigationLink);
            }

            return await client.GetDatastreamCollectionByThing(Id, odata);
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>> GetHistoricalLocations(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(HistoricalLocationsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<HistoricalLocation>>(HistoricalLocationsNavigationLink);
            }

            return await client.GetHistoricalLocationsCollectionByThing(Id, odata);
        }

        public async Task<Response<SensorThingsCollection<Location>>> GetLocations(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(LocationsNavigationLink))
            {
                return await Http.GetJson<SensorThingsCollection<Location>>(LocationsNavigationLink);
            }

            return await client.GetLocationCollectionByThing(Id, odata);
        }
    }
}
