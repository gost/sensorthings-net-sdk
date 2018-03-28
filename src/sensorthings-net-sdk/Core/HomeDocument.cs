using Newtonsoft.Json;
using System.Linq;

namespace SensorThings.Core
{
    public class HomeDocument
    {
        [JsonProperty("value")]
        public Entity[] Entities { get; set; }

        public string GetUrlByEntityName(string name)
        {
            var url = (from i in Entities where i.Name == name select i.Url).FirstOrDefault();
            return url;
        }
    }

    public class Entity
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
