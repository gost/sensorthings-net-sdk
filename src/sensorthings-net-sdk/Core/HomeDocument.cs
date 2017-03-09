using Newtonsoft.Json;
using System.Linq;

namespace SensorThings.Core
{
    public class HomeDocument
    {
        [JsonProperty("value")]
        public Entity[] Entities { get; set; }

        public string GetUrlByEntityName(string Name)
        {
            var url = (from i in Entities where i.Name == Name select i.Url).FirstOrDefault();
            return url;
        }
    }

    public class Entity
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
