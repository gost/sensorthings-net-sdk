using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.OData;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
namespace SensorThings.Client.Extensions {
    public static class ThingExtensions {
        public static async Task<SensorThingsCollection<Datastream>> GetDatastreams(
            this Thing thing, ISensorThingsEntityHandler entityHandler, OdataQuery odata = null) {
            return await entityHandler.SearchEntities<Datastream, Thing>(thing, odata);
        }

        public static async Task<SensorThingsCollection<HistoricalLocation>> GetHistoricalLocations(
            this Thing thing, ISensorThingsEntityHandler entityHandler, OdataQuery odata = null) {
            return await entityHandler.SearchEntities<HistoricalLocation, Thing>(thing, odata);
        }

        public static async Task<SensorThingsCollection<Location>> GetLocations(
            this Thing thing, ISensorThingsEntityHandler entityHandler, OdataQuery odata = null) {
            return await entityHandler.SearchEntities<Location, Thing>(thing, odata);
        }
    }
}
