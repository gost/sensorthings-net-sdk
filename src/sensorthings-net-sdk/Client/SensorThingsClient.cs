using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.OData;

namespace SensorThings.Client {
    public class SensorThingsClient : ISensorThingsClient {
        private readonly ISensorThingsEntityHandler _entityHandler;

        public SensorThingsClient(string server) { _entityHandler = new SensorThingsEntityHandler(server); }

        public async Task<Response<Thing>> GetThing(string id, OdataQuery odata = null) {
            return await GetEntity<Thing>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<Thing>> GetThingByDatastream(string id, OdataQuery odata = null) {
            return await GetEntityBy<Thing, Datastream>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<Thing>> GetThingByHistoricalLocation(string id, OdataQuery odata = null) {
            return await GetEntityBy<Thing, HistoricalLocation>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Thing>>> GetThingCollection(OdataQuery odata = null) {
            return await GetEntities<Thing>(odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Thing>>> GetThingCollectionByLocation(
            string id, OdataQuery odata = null) {
            return await GetEntitiesBy<Thing, Location>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<Location>> GetLocation(string id, OdataQuery odata = null) {
            return await GetEntity<Location>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Location>>> GetLocationCollection(OdataQuery odata = null) {
            return await GetEntities<Location>(odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Location>>>
            GetLocationCollectionByHistoricalLocation(string id, OdataQuery odata = null) {
            return await GetEntitiesBy<Location, HistoricalLocation>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Location>>> GetLocationCollectionByThing(
            string id, OdataQuery odata = null) {
            return await GetEntitiesBy<Location, Thing>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<HistoricalLocation>> GetHistoricalLocation(string id, OdataQuery odata = null) {
            return await GetEntity<HistoricalLocation>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>>
            GetHistoricalLocationsCollection(OdataQuery odata = null) {
            return await GetEntities<HistoricalLocation>(odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>>
            GetHistoricalLocationsCollectionByLocation(string id, OdataQuery odata = null) {
            return await GetEntitiesBy<HistoricalLocation, Location>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>>
            GetHistoricalLocationsCollectionByThing(string id, OdataQuery odata = null) {
            return await GetEntitiesBy<HistoricalLocation, Thing>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<Datastream>> GetDatastream(string id, OdataQuery odata = null) {
            return await GetEntity<Datastream>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<Datastream>> GetDatastreamByObservation(string id, OdataQuery odata = null) {
            return await GetEntityBy<Datastream, Observation>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>>
            GetDatastreamCollection(OdataQuery odata = null) {
            return await GetEntities<Datastream>(odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>>
            GetDatastreamCollectionByObservedProperty(string id, OdataQuery odata = null) {
            return await GetEntitiesBy<Datastream, ObservedProperty>(id, odata)
                .ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>>
            GetDatastreamCollectionBySensor(string id, OdataQuery odata = null) {
            return await GetEntitiesBy<Datastream, Sensor>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>>
            GetDatastreamCollectionByThing(string id, OdataQuery odata = null) {
            return await GetEntitiesBy<Datastream, Thing>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<Sensor>> GetSensor(string id, OdataQuery odata = null) {
            return await GetEntity<Sensor>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Sensor>>> GetSensorCollection(OdataQuery odata = null) {
            return await GetEntities<Sensor>(odata).ConfigureAwait(false);
        }

        public async Task<Response<Sensor>> GetSensorByDatastream(string id, OdataQuery odata = null) {
            return await GetEntityBy<Sensor, Datastream>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<ObservedProperty>> GetObservedProperty(string id, OdataQuery odata = null) {
            return await GetEntity<ObservedProperty>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<ObservedProperty>>>
            GetObservedPropertyCollection(OdataQuery odata = null) {
            return await GetEntities<ObservedProperty>(odata).ConfigureAwait(false);
        }

        public async Task<Response<ObservedProperty>> GetObservedPropertyByDatastream(
            string id, OdataQuery odata = null) {
            return await GetEntityBy<ObservedProperty, Datastream>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<Observation>> GetObservation(string id, OdataQuery odata = null) {
            return await GetEntity<Observation>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Observation>>>
            GetObservationCollection(OdataQuery odata = null) {
            return await GetEntities<Observation>(odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Observation>>>
            GetObservationCollectionByFeatureOfInterest(string id, OdataQuery odata = null) {
            return await GetEntitiesBy<Observation, FeatureOfInterest>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<Observation>>>
            GetObservationCollectionByDatastream(string id, OdataQuery odata = null) {
            return await GetEntitiesBy<Observation, Datastream>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<FeatureOfInterest>> GetFeatureOfInterest(string id, OdataQuery odata = null) {
            return await GetEntity<FeatureOfInterest>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<FeatureOfInterest>> GetFeatureOfInterestByObservation(
            string id, OdataQuery odata = null) {
            return await GetEntityBy<FeatureOfInterest, Observation>(id, odata).ConfigureAwait(false);
        }

        public async Task<Response<SensorThingsCollection<FeatureOfInterest>>>
            GetFeatureOfInterestCollection(OdataQuery odata = null) {
            return await GetEntities<FeatureOfInterest>(odata).ConfigureAwait(false);
        }

        private async Task<Response<T>> GetEntity<T>(string id, OdataQuery odata)
            where T : AbstractEntity =>
            await _entityHandler.GetEntity<T>(id, odata).ConfigureAwait(false);

        private async Task<Response<T>> GetEntityBy<T, T2>(string byId, OdataQuery odata)
            where T : AbstractEntity
            where T2 : AbstractEntity, new() =>
            await _entityHandler.GetEntity<T, T2>(new T2 { Id = byId }, odata).ConfigureAwait(false);

        private async Task<Response<SensorThingsCollection<T>>> GetEntities<T>(OdataQuery odata)
            where T : AbstractEntity =>
            await _entityHandler.GetEntities<T>(odata).ConfigureAwait(false);

        private async Task<Response<SensorThingsCollection<T>>> GetEntitiesBy<T, T2>(string byId, OdataQuery odata)
            where T : AbstractEntity
            where T2 : AbstractEntity, new() =>
            await _entityHandler.GetEntities<T, T2>(new T2 { Id = byId }, odata).ConfigureAwait(false);
    }
}
