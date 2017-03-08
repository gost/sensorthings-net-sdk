using System.Collections.Generic;

namespace SensorThings.Core
{
    public class Sensor:AbstractEntity
    {
        public Sensor()
        {
        }

        public Sensor(string SelfLink, string NavigationLink)
        {
            this.SelfLink = SelfLink;
        }
        public List<Datastream> Datastreams { get; set; }
        public string Name { get; set; }
        public string Descrpition { get; set; }
        public object Metadata { get; set; }
    }
}
