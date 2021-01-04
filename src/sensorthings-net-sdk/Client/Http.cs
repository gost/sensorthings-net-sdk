using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using SensorThings.Core;

namespace SensorThings.Client {
    public static class Http {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {
            NullValueHandling = NullValueHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.None,
        };

        private static readonly HttpClient Client = new HttpClient();

        public static async Task<Response<T>> GetJson<T>(Uri url) {
            _ = url ?? throw new ArgumentNullException(nameof(url));

            return await ExecuteAndCreateResponse<T>(Client.GetAsync(url), HttpStatusCode.OK).ConfigureAwait(false);
        }

        [Obsolete("GetJson(string) is deprecated, please use GetJson(Uri) instead.")]
        public static async Task<Response<T>> GetJson<T>(string url) =>
            await GetJson<T>(new Uri(url)).ConfigureAwait(false);

        public static async Task<Response<T>> PostJson<T>(Uri url, T entity) {
            _ = url ?? throw new ArgumentNullException(nameof(url));

            using (var content = EntityToContent(entity)) {
                return await ExecuteAndCreateResponse<T>(Client.PostAsync(url, content), HttpStatusCode.Created)
                    .ConfigureAwait(false);
            }
        }

        public static async Task<Response<T>> PatchJson<T>(Uri url, T entity) {
            _ = url ?? throw new ArgumentNullException(nameof(url));

            using (var content = EntityToContent(entity)) {
                return await ExecuteAndCreateResponse<T>(Client.PutAsync(url, content), HttpStatusCode.OK)
                    .ConfigureAwait(false);
            }
        }

        public static async Task<Response<T>> DeleteJson<T>(Uri url) {
            _ = url ?? throw new ArgumentNullException(nameof(url));

            return await ExecuteAndCreateResponse<T>(Client.DeleteAsync(url), HttpStatusCode.OK).ConfigureAwait(false);
        }

        private static HttpContent EntityToContent<T>(T entity) {
            var serialized = JsonConvert.SerializeObject(entity, Settings);
            return new StringContent(serialized, Encoding.UTF8, "application/json");
        }

        private static async Task<Response<T>> ExecuteAndCreateResponse<T>(
            Task<HttpResponseMessage> request, HttpStatusCode expectedStatus) {
            var responseMessage = await request.ConfigureAwait(false);
            var responseString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var location = GetEntityLocation(responseMessage);

            return responseMessage.StatusCode == expectedStatus
                ? Response<T>.CreateSuccessful(location, JsonConvert.DeserializeObject<T>(responseString),
                    responseMessage.StatusCode)
                : Response<T>.CreateUnsuccessful(location, responseString, responseMessage.StatusCode);
        }

        private static Uri GetEntityLocation(HttpResponseMessage responseMessage) {
            var requestlocation = responseMessage.RequestMessage.RequestUri;
            var reponselocation = responseMessage.Headers?.Location;
            if (reponselocation == null) {
                return requestlocation;
            }

            // note: this little trick replaces the last path segment with the given string
            // and this string is 'EntityName(Id)'.
            return new Uri(requestlocation, reponselocation.Segments.Last());
        }
    }
}
