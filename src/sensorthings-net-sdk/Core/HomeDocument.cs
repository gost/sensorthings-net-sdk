using System.Linq;

namespace SensorThings.Core
{
    public class HomeDocument
    {
        public Value[] value { get; set; }

        public string GetUrlByEntity(string Entity)
        {
            var url = (from i in value where i.name == Entity select i.url).FirstOrDefault();
            return url;
        }
    }

    public class Value
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
