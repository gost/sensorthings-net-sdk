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

        public SensorThingsCollection<Datastream> GetDatastreams()
        {
            return Http.GetJson<SensorThingsCollection<Datastream>>(DatastreamsNavigationLink);
        }

    }
}
