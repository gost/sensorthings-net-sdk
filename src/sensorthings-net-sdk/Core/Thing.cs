using Newtonsoft.Json;
using SensorThings.Client;
using System.Collections.Generic;

namespace SensorThings.Core
{
    public class Thing: AbstractEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string,object> Properties { get; set; }
        [JsonProperty("Datastreams@iot.navigationLink")]
        public string DatastreamsNavigationLink { get; set; }
        [JsonProperty("HistoricalLocations@iot.navigationLink")]
        public string HistoricalLocationsNavigationLink { get; set; }
        [JsonProperty("Locations@iot.navigationLink")]
        public string LocationsNavigationLink { get; set; }

        public SensorThingsCollection<Datastream> GetDatastreams()
        {
            return Http.GetJson<SensorThingsCollection<Datastream>>(DatastreamsNavigationLink);
        }

        public SensorThingsCollection<HistoricalLocation> GetHistoricalLocations()
        {
            return Http.GetJson<SensorThingsCollection<HistoricalLocation>>(HistoricalLocationsNavigationLink);
        }

        public SensorThingsCollection<Location> GetLocations()
        {
            return Http.GetJson<SensorThingsCollection<Location>>(LocationsNavigationLink);
        }
    }
}
