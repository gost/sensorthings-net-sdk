using System.Collections.Generic;

namespace SensorThings.Core
{
    public class Thing: AbstractEntity
    {
        public Thing()
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string,object> Properties { get; set; }
        public List<Location> Locations { get; set; }
        public List<HistoricalLocation> HistoricalLocations { get; set; }
        public List<Datastream> Datastreams { get; set; }
    }
}
