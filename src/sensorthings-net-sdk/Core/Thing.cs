using Newtonsoft.Json;
using SensorThings.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<SensorThingsCollection<Datastream>> GetDatastreams()
        {
            return await Http.GetJson<SensorThingsCollection<Datastream>>(DatastreamsNavigationLink);
        }

        public async Task<SensorThingsCollection<HistoricalLocation>> GetHistoricalLocations()
        {
            return await Http.GetJson<SensorThingsCollection<HistoricalLocation>>(HistoricalLocationsNavigationLink);
        }

        public async Task<SensorThingsCollection<Location>> GetLocations()
        {
            return await Http.GetJson<SensorThingsCollection<Location>>(LocationsNavigationLink);
        }
    }
}
