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

        private T GetJson<T>(string url)
        {
            var response = httpClient.GetAsync(url).Result;
            string strJson = response.Content.ReadAsStringAsync().Result;
            var fois = JsonConvert.DeserializeObject<T>(strJson);
            return fois;
        }
    }
}
