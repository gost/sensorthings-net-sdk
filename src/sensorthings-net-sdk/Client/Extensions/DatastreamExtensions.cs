using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.OData;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
namespace SensorThings.Client.Extensions {
    public static class DatastreamExtensions {
        public static async Task<SensorThingsCollection<Observation>> GetObservations(
            this Datastream datastream, ISensorThingsEntityHandler entityHandler, OdataQuery odata = null) {
            return await entityHandler.SearchEntities<Observation, Datastream>(datastream, odata);
        }

        public static async Task<ObservedProperty> GetObservedProperty(
            this Datastream datastream, ISensorThingsEntityHandler entityHandler, OdataQuery odata = null) {
            return await entityHandler.SearchEntity<ObservedProperty, Datastream>(datastream, odata);
        }

        public static async Task<Sensor> GetSensor(
            this Datastream datastream, ISensorThingsEntityHandler entityHandler, OdataQuery odata = null) {
            return await entityHandler.SearchEntity<Sensor, Datastream>(datastream, odata);
        }

        public static async Task<Thing> GetThing(
            this Datastream datastream, ISensorThingsEntityHandler entityHandler, OdataQuery odata = null) {
            return await entityHandler.SearchEntity<Thing, Datastream>(datastream, odata);
        }
    }
}