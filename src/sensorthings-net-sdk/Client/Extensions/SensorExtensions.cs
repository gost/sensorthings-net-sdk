using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.OData;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
namespace SensorThings.Client.Extensions {
    public static class SensorExtensions {
        public static async Task<SensorThingsCollection<Datastream>> GetDatastreams(
            this Sensor sensor, ISensorThingsEntityHandler entityHandler, OdataQuery odata = null) {
            return await entityHandler.SearchEntities<Datastream, Sensor>(sensor, odata);
        }
    }
}