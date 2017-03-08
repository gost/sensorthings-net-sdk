using Newtonsoft.Json;
using SensorThings.Core;
using System.Net.Http;

namespace SensorThings.Client
{
    public class SensorThingsClient
    {
        private HttpClient httpClient;

        public SensorThingsClient(string Server)
        {
            this.Server = Server;
            httpClient = new HttpClient();
        }

        public string Server { get; set; }

        public FeatureOfInterest GetFeatureOfInterest()
        {
            var url = Server + "FeatureOfInterest";
            var foi = GetJson<FeatureOfInterest>(url);
            return foi;
        }

        public SensorThingsCollection<FeatureOfInterest> GetFeatureOfInterestCollection()
        {
            var url = Server + "FeaturesOfInterest";
            var fois = GetJson<SensorThingsCollection<FeatureOfInterest>>(url);
            return fois;
        }

        public ObservedProperty GetObservedProperty()
        {
            var url = Server + "ObservedProperty";
            var observedProperty = GetJson<ObservedProperty>(url);
            return observedProperty;
        }

        public SensorThingsCollection<ObservedProperty> GetObservedPropertyCollection()
        {
            var url = Server + "ObservedProperties";
            var observedProperties = GetJson<SensorThingsCollection<ObservedProperty>>(url);
            return observedProperties;
        }

        public Location GetLocation(int id)
        {
            var url = Server + $"Locations({id})";
            var location = GetJson<Location>(url);
            return location;
        }

        public SensorThingsCollection<Location> GetLocationCollection()
        {
            var url = Server + "Locations";
            var locations = GetJson<SensorThingsCollection<Location>>(url);
            return locations;
        }

        public Observation GetObservation(int id)
        {
            var url = Server + $"Observations({id})";
            var observation = GetJson<Observation>(url);
            return observation;
        }

        public SensorThingsCollection<Observation> GetObservationCollection()
        {
            var url = Server + "Observations";
            var observations = GetJson<SensorThingsCollection<Observation>>(url);
            return observations;
        }

        public HistoricalLocation GetHistoricalLocation(int id)
        {
            var url = Server + $"HistoricalLocations({id})";
            var historicalLocation = GetJson<HistoricalLocation>(url);
            return historicalLocation;
        }

        public SensorThingsCollection<HistoricalLocation> GetHistoricalLocationsCollection()
        {
            var url = Server + "HistoricalLocations";
            var historicalLocations = GetJson<SensorThingsCollection<HistoricalLocation>>(url);
            return historicalLocations;
        }

        public Sensor GetSensor(int id)
        {
            var url = Server + $"Sensors({id})";
            var sensor = GetJson<Sensor>(url);
            return sensor;
        }

        public SensorThingsCollection<Sensor> GetSensorCollection()
        {
            var url = Server + "Sensors";
            var sensors = GetJson<SensorThingsCollection<Sensor>>(url);
            return sensors;
        }

        public Datastream GetDatastream(int id)
        {
            var url = Server + $"Datastreams({id})";
            var datastream = GetJson<Datastream>(url);
            return datastream;
        }

        public SensorThingsCollection<Datastream> GetDatastreamCollection()
        {
            var url = Server + "Datastreams";
            var datastreams = GetJson<SensorThingsCollection<Datastream>>(url);
            return datastreams;
        }

        public Thing GetThing(int id)
        {
            var url = Server + $"Things({id})";
            var thing = GetJson<Thing>(url);
            return thing;
        }

        public SensorThingsCollection<Thing> GetThingCollection()
        {
            var url = Server + "Things";
            var things = GetJson<SensorThingsCollection<Thing>>(url);
            return things;
        }
        
        private T GetJson<T>(string url)
        {
            var response = httpClient.GetAsync(url).Result;
            string strJson = response.Content.ReadAsStringAsync().Result;
            var fois = JsonConvert.DeserializeObject<T>(strJson);
            return fois;
        }



    }
}
