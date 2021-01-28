using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.OData;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
namespace SensorThings.Client.Extensions {
    public static class HistoricalLocationExtensions {
        public static async Task<SensorThingsCollection<Location>> GetLocations(
            this HistoricalLocation historicalLocation, ISensorThingsEntityHandler entityHandler,
            OdataQuery odata = null) {
            return await entityHandler.SearchEntities<Location, HistoricalLocation>(historicalLocation, odata);
        }

        public static async Task<Thing> GetThing(
            this HistoricalLocation historicalLocation, ISensorThingsEntityHandler entityHandler,
            OdataQuery odata = null) {
            return await entityHandler.SearchEntity<Thing, HistoricalLocation>(historicalLocation, odata);
        }
    }
}