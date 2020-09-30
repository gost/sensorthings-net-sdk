using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using sensorthings.Core;

namespace SensorThings.Client
{
    public static class Http
    {
        private static readonly HttpClient Client = new HttpClient();

        public static async Task<Response<T>> GetJson<T>(string url, HttpStatusCode expectedStatus = HttpStatusCode.OK)
        {
            return await ExecuteAndCreateResponse<T>(Client.GetAsync(url), expectedStatus);
        }

        public static async Task<Response<T>> PostJson<T>(string url, T entity, HttpStatusCode expectedStatus = HttpStatusCode.Created)
        {
            var serialized = JsonConvert.SerializeObject(entity, Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore,
                                DateTimeZoneHandling = DateTimeZoneHandling.Utc
                            });

            var content = new StringContent(serialized, Encoding.UTF8, "application/json");
            return await ExecuteAndCreateResponse<T>(Client.PostAsync(url, content), expectedStatus);
        }

        private static async Task<Response<T>> ExecuteAndCreateResponse<T>(Task<HttpResponseMessage> request, HttpStatusCode expectedStatus)
        {
            var responseMessage = await request;
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            return responseMessage.StatusCode == expectedStatus ?
                Response<T>.CreateSuccessful(JsonConvert.DeserializeObject<T>(responseString), responseMessage.StatusCode) :
                Response<T>.CreateUnsuccessful(responseString, responseMessage.StatusCode);
        }
    }
}