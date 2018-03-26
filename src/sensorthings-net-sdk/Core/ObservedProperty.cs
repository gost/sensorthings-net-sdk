using System.Threading.Tasks;
using Newtonsoft.Json;
using SensorThings.Client;

namespace SensorThings.Core
{
    public class ObservedProperty:AbstractEntity
    {
        public string Description { get; set; }
        public string Definition { get; set; }
        public string Name { get; set; }
        [JsonProperty("Datastreams@iot.navigationLink")]
        public string DatastreamsNavigationLink { get; set; }

        public async Task<SensorThingsCollection<Datastream>> GetDatastreams()
        {
            return await Http.GetJson<SensorThingsCollection<Datastream>>(DatastreamsNavigationLink);
        }
    }
}
