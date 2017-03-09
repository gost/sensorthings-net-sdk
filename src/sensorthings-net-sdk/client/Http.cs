using Newtonsoft.Json;
using System.Net.Http;

namespace SensorThings.Client
{
    public static class Http
    {
        public static T GetJson<T>(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            string strJson = response.Content.ReadAsStringAsync().Result;
            var items = JsonConvert.DeserializeObject<T>(strJson);
            return items;
        }
    }
}
