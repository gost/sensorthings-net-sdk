using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.OData;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
namespace SensorThings.Client.Extensions {
    public static class FeatureOfInterestExtensions {
        public static async Task<SensorThingsCollection<Observation>> GetObservations(
            this FeatureOfInterest featureOfInterest, ISensorThingsEntityHandler entityHandler,
            OdataQuery odata = null) {
            return await entityHandler.SearchEntities<Observation, FeatureOfInterest>(featureOfInterest, odata);
        }
    }
}