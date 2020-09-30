using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using sensorthings.Core;

namespace SensorThings.Client {
    public static class Http {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.None,
        };

        private static readonly HttpClient Client = new HttpClient();

        public static async Task<Response<T>> GetJson<T>(string url) {
            return await ExecuteAndCreateResponse<T>(Client.GetAsync(url), HttpStatusCode.OK);
        }

        public static async Task<Response<T>> PostJson<T>(string url, T entity) {
            var serialized = JsonConvert.SerializeObject(entity, Settings);
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            return await ExecuteAndCreateResponse<T>(Client.PostAsync(url, content), HttpStatusCode.Created);
        }

        public static async Task<Response<T>> PatchJson<T>(string url, T entity) {
            var serialized = JsonConvert.SerializeObject(entity, Settings);
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            return await ExecuteAndCreateResponse<T>(Client.PatchAsync(url, content), HttpStatusCode.OK);
        }

        public static async Task<Response<T>> DeleteJson<T>(string url) {
            return await ExecuteAndCreateResponse<T>(Client.DeleteAsync(url), HttpStatusCode.OK);
        }

        private static async Task<Response<T>> ExecuteAndCreateResponse<T>(
            Task<HttpResponseMessage> request, HttpStatusCode expectedStatus) {
            var responseMessage = await request;
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            return responseMessage.StatusCode == expectedStatus
                ? Response<T>.CreateSuccessful(JsonConvert.DeserializeObject<T>(responseString),
                    responseMessage.StatusCode)
                : Response<T>.CreateUnsuccessful(responseString, responseMessage.StatusCode);
        }
    }
}
