using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.OData;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
namespace SensorThings.Client.Extensions {
    public static class ObservationExtensions {
        public static async Task<Datastream> GetDatastream(
            this Observation observation, ISensorThingsEntityHandler entityHandler, OdataQuery odata = null) {
            return await entityHandler.SearchEntity<Datastream, Observation>(observation, odata);
        }

        public static async Task<FeatureOfInterest> GetFeatureOfInterest(
            this Observation observation, ISensorThingsEntityHandler entityHandler, OdataQuery odata = null) {
            return await entityHandler.SearchEntity<FeatureOfInterest, Observation>(observation, odata);
        }
    }
}