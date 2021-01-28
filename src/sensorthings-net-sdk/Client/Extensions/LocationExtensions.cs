using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.OData;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
namespace SensorThings.Client.Extensions {
    public static class LocationExtensions {
        public static async Task<SensorThingsCollection<Thing>> GetThings(
            this Location location, ISensorThingsEntityHandler entityHandler, OdataQuery odata = null) {
            return await entityHandler.SearchEntities<Thing, Location>(location, odata);
        }

        public static async Task<SensorThingsCollection<HistoricalLocation>> GetHistoricalLocations(
            this Location location, ISensorThingsEntityHandler entityHandler, OdataQuery odata = null) {
            return await entityHandler.SearchEntities<HistoricalLocation, Location>(location, odata);
        }
    }
}