using System.Threading.Tasks;

using sensorthings.Core;

using SensorThings.Core;

using sensorthings.ODATA;

namespace SensorThings.Client {
    public interface ISensorThingsClient {
        Task<Response<Thing>> GetThing(string id, OdataQuery odata = null);
        Task<Response<Thing>> GetThingByDatastream(string id, OdataQuery odata = null);
        Task<Response<Thing>> GetThingByHistoricalLocation(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Thing>>> GetThingCollection(OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Thing>>> GetThingCollectionByLocation(string id, OdataQuery odata = null);
        Task<Response<Location>> GetLocation(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Location>>> GetLocationCollection(OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Location>>> GetLocationCollectionByHistoricalLocation(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Location>>> GetLocationCollectionByThing(string id, OdataQuery odata = null);
        Task<Response<HistoricalLocation>> GetHistoricalLocation(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<HistoricalLocation>>> GetHistoricalLocationsCollection(OdataQuery odata = null);
        Task<Response<SensorThingsCollection<HistoricalLocation>>> GetHistoricalLocationsCollectionByLocation(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<HistoricalLocation>>> GetHistoricalLocationsCollectionByThing(string id, OdataQuery odata = null);
        Task<Response<Datastream>> GetDatastream(string id, OdataQuery odata = null);
        Task<Response<Datastream>> GetDatastreamByObservation(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Datastream>>> GetDatastreamCollection(OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Datastream>>> GetDatastreamCollectionByObservedProperty(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Datastream>>> GetDatastreamCollectionBySensor(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Datastream>>> GetDatastreamCollectionByThing(string id, OdataQuery odata = null);
        Task<Response<Sensor>> GetSensor(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Sensor>>> GetSensorCollection(OdataQuery odata = null);
        Task<Response<Sensor>> GetSensorByDatastream(string id, OdataQuery odata = null);
        Task<Response<ObservedProperty>> GetObservedProperty(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<ObservedProperty>>> GetObservedPropertyCollection(OdataQuery odata = null);
        Task<Response<ObservedProperty>> GetObservedPropertyByDatastream(string id, OdataQuery odata = null);
        Task<Response<Observation>> GetObservation(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Observation>>> GetObservationCollection(OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Observation>>> GetObservationCollectionByFeatureOfInterest(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<Observation>>> GetObservationCollectionByDatastream(string id, OdataQuery odata = null);
        Task<Response<FeatureOfInterest>> GetFeatureOfInterest(string id, OdataQuery odata = null);
        Task<Response<FeatureOfInterest>> GetFeatureOfInterestByObservation(string id, OdataQuery odata = null);
        Task<Response<SensorThingsCollection<FeatureOfInterest>>> GetFeatureOfInterestCollection(OdataQuery odata = null);
        // CRUD functions for entities
        Task<Response<T>> Create<T>(T entity) where T : AbstractEntity;
        Task<Response<T>> Read<T>(T entity) where T : AbstractEntity;
        Task<Response<T>> Update<T>(T entity) where T : AbstractEntity;
        Task<Response<T>> Delete<T>(T entity) where T : AbstractEntity;
    }
}
