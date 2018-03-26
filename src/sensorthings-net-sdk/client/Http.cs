using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SensorThings.Client
{
    public static class Http
    {
        public static async Task<T> GetJson<T>(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var strJson = await response.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<T>(strJson);
            return items;
        }

        public static async Task<T> PostJson<T>(string url, T entity)
        {
            var client = new HttpClient();
            var serialized = JsonConvert.SerializeObject(entity, Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore,
                                DateTimeZoneHandling = DateTimeZoneHandling.Utc
                            });
            var buffer = System.Text.Encoding.UTF8.GetBytes(serialized);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseMessage = await client.PostAsync(url, byteContent);
            var response = await responseMessage.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<T>(response);
            return item;
        }
    }
}