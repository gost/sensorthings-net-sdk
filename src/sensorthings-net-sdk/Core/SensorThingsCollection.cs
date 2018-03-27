using Newtonsoft.Json;
using SensorThings.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using sensorthings.Core;

namespace SensorThings.Core
{
    public class SensorThingsCollection<T>
    {
        [JsonProperty("@iot.count")]
        public int Count { get; set; }

        [JsonProperty("@iot.nextLink")]
        public string NextLink { get; set; }

        [JsonProperty("value")]
        public IReadOnlyList<T> Items { get; set; }

        public bool HasNextPage()
        {
            return !string.IsNullOrEmpty(NextLink);
        }

        public async Task<Response<SensorThingsCollection<T>>> GetNextPage()
        {
            return HasNextPage() ? null : await Http.GetJson<SensorThingsCollection<T>>(NextLink);
        }
    }
}
