using System.Threading.Tasks;
using SensorThings.Core;

namespace SensorThings.Client
{
    public class SensorThingsClient
    {
        private HomeDocument _homedoc;

        public string Server { get; set; }

        public SensorThingsClient(string server)
        {
            Server = server;
            Task.Run(async () => _homedoc = await Http.GetJson<HomeDocument>(Server)).Wait();
        }

        public async Task<Thing> GetThing(string id)
        {
            var url = _homedoc.GetUrlByEntityName("Things") + $"({id})";
            var thing = await Http.GetJson<Thing>(url);
            return thing;
        }

        public async Task<SensorThingsCollection<Thing>> GetThingCollection()
        {
            var url = _homedoc.GetUrlByEntityName("Things");
            var things = await Http.GetJson<SensorThingsCollection<Thing>>(url);
            return things;
        }

        public async Task<Location> GetLocation(string id)
        {
            var url = _homedoc.GetUrlByEntityName("Locations") + $"({id})";
            var location = await Http.GetJson<Location>(url);
            return location;
        }

        public async Task<SensorThingsCollection<Location>> GetLocationCollection()
        {
            var url = _homedoc.GetUrlByEntityName("Locations");
            var locations = await Http.GetJson<SensorThingsCollection<Location>>(url);
            return locations;
        }

        public async Task<HistoricalLocation> GetHistoricalLocation(string id)
        {
            var url = _homedoc.GetUrlByEntityName("HistoricalLocations") + $"({id})";
            var historicalLocation = await Http.GetJson<HistoricalLocation>(url);
            return historicalLocation;
        }

        public async Task<SensorThingsCollection<HistoricalLocation>> GetHistoricalLocationsCollection()
        {
            var url = _homedoc.GetUrlByEntityName("HistoricalLocations");
            var historicalLocations = await Http.GetJson<SensorThingsCollection<HistoricalLocation>>(url);
            return historicalLocations;
        }

        public async Task<Datastream> GetDatastream(string id)
        {
            var url = _homedoc.GetUrlByEntityName("Datastreams") + $"({id})";
            var datastream = await Http.GetJson<Datastream>(url);
            return datastream;
        }

        public async Task<SensorThingsCollection<Datastream>> GetDatastreamCollection(string url)
        {
            var datastreams = await Http.GetJson<SensorThingsCollection<Datastream>>(url);
            return datastreams;
        }

        public async Task<SensorThingsCollection<Datastream>> GetDatastreamCollection()
        {
            var url = _homedoc.GetUrlByEntityName("Datastreams");
            return await GetDatastreamCollection(url);
        }

        public async Task<Sensor> GetSensor(string id)
        {
            var url = _homedoc.GetUrlByEntityName("Sensors") + $"({id})";
            var sensor = await Http.GetJson<Sensor>(url);
            return sensor;
        }

        public async Task<SensorThingsCollection<Sensor>> GetSensorCollection()
        {
            var url = _homedoc.GetUrlByEntityName("Sensors");
            var sensors = await Http.GetJson<SensorThingsCollection<Sensor>>(url);
            return sensors;
        }

        public async Task<ObservedProperty> GetObservedProperty(string id)
        {
            var url = _homedoc.GetUrlByEntityName("ObservedProperties") + $"({id})";
            var observedProperty = await Http.GetJson<ObservedProperty>(url);
            return observedProperty;
        }

        public async Task<SensorThingsCollection<ObservedProperty>> GetObservedPropertyCollection()
        {
            var url = _homedoc.GetUrlByEntityName("ObservedProperties");
            var observedProperties = await Http.GetJson<SensorThingsCollection<ObservedProperty>>(url);
            return observedProperties;
        }

        public async Task<Observation> GetObservation(string id)
        {
            var url = _homedoc.GetUrlByEntityName("Observations") + $"({id})";
            var observation = await Http.GetJson<Observation>(url);
            return observation;
        }

        public async Task<SensorThingsCollection<Observation>> GetObservationCollection()
        {
            var url = _homedoc.GetUrlByEntityName("Observations");
            var observations = await Http.GetJson<SensorThingsCollection<Observation>>(url);
            return observations;
        }

        public async Task<FeatureOfInterest> GetFeatureOfInterest(string id)
        {
            var url = _homedoc.GetUrlByEntityName("FeaturesOfInterest") + $"({id})";
            var foi = await Http.GetJson<FeatureOfInterest>(url);
            return foi;
        }

        public async Task<SensorThingsCollection<FeatureOfInterest>> GetFeatureOfInterestCollection()
        {
            var url = _homedoc.GetUrlByEntityName("FeaturesOfInterest");
            var fois = await Http.GetJson<SensorThingsCollection<FeatureOfInterest>>(url);
            return fois;
        }

        public async Task<Observation> CreateObservation(Observation observation)
        {
            var url = _homedoc.GetUrlByEntityName("Observations");
            var responseObservation = await Http.PostJson<Observation>(url, observation);
            return responseObservation;
        }
    }
}
