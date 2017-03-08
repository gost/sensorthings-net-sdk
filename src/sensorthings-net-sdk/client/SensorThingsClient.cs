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

        private T GetJson<T>(string url)
        {
            var response = httpClient.GetAsync(url).Result;
            string strJson = response.Content.ReadAsStringAsync().Result;
            var fois = JsonConvert.DeserializeObject<T>(strJson);
            return fois;
        }



    }
}
