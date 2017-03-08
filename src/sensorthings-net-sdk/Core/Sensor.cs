using System.Collections.Generic;

namespace SensorThings.Core
{
    public class Sensor:AbstractEntity
    {
        public Sensor()
        {
        }

        public List<Datastream> Datastreams { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public object Metadata { get; set; }
    }
}
