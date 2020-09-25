using System;
using System.Threading.Tasks;
using sensorthings;
using sensorthings.Core;
using sensorthings.Extensions;
using sensorthings.ODATA;
using SensorThings.Core;

namespace SensorThings.Client
{
    public class SensorThingsClient : ISensorThingsClient {
        private HomeDocument _homedoc;

        public string Server { get; set; }

        public SensorThingsClient(string server)
        {
            Server = server;
            Task.Run(async () =>
            {
                var response = await Http.GetJson<HomeDocument>(Server);
                if (!response.Success)
                {
                    throw new Exception("Unable to get home document");
                }

                return _homedoc = response.Result;
            }).Wait();
        }

        public async Task<Response<Thing>> GetThing(string id, OdataQuery odata = null)
        {
            return await Get<Thing>(EntityType.Thing, id, odata);
        }

        public async Task<Response<Thing>> GetThingByDatastream(string id, OdataQuery odata = null)
        {
            return await Get<Thing>(EntityType.Thing, EntityType.Datastream, id, odata);
        }

        public async Task<Response<Thing>> GetThingByHistoricalLocation(string id, OdataQuery odata = null)
        {
            return await Get<Thing>(EntityType.Thing, EntityType.HistoricalLocation, id, odata);
        }

        public async Task<Response<SensorThingsCollection<Thing>>> GetThingCollection(OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Thing>>(EntityType.Thing, odata);
        }

        public async Task<Response<SensorThingsCollection<Thing>>> GetThingCollectionByLocation(string id, OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Thing>>(EntityType.Thing, EntityType.Location, id, odata);
        }

        public async Task<Response<Location>> GetLocation(string id, OdataQuery odata = null)
        { 
            return await Get<Location>(EntityType.Location, id, odata);
        }

        public async Task<Response<SensorThingsCollection<Location>>> GetLocationCollection(OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Location>>(EntityType.Location, odata);
        }

        public async Task<Response<SensorThingsCollection<Location>>> GetLocationCollectionByHistoricalLocation(string id, OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Location>>(EntityType.Location, EntityType.HistoricalLocation, id, odata);
        }

        public async Task<Response<SensorThingsCollection<Location>>> GetLocationCollectionByThing(string id, OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Location>>(EntityType.Location, EntityType.Thing, id, odata);
        }

        public async Task<Response<HistoricalLocation>> GetHistoricalLocation(string id, OdataQuery odata = null)
        {
            return await Get<HistoricalLocation>(EntityType.HistoricalLocation, id, odata);
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>> GetHistoricalLocationsCollection(OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<HistoricalLocation>>(EntityType.HistoricalLocation, odata);            
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>> GetHistoricalLocationsCollectionByLocation(string id, OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<HistoricalLocation>>(EntityType.HistoricalLocation, EntityType.Location, id, odata);
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>> GetHistoricalLocationsCollectionByThing(string id, OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<HistoricalLocation>>(EntityType.HistoricalLocation, EntityType.Thing, id, odata);
        }

        public async Task<Response<Datastream>> GetDatastream(string id, OdataQuery odata = null)
        {
            return await Get<Datastream>(EntityType.Datastream, id, odata);
        }

        public async Task<Response<Datastream>> GetDatastreamByObservation(string id, OdataQuery odata = null)
        {
            return await Get<Datastream>(EntityType.Datastream, EntityType.Observation, id, odata);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>> GetDatastreamCollection(OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Datastream>>(EntityType.Datastream, odata);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>> GetDatastreamCollectionByObservedProperty(string id, OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Datastream>>(EntityType.Datastream, EntityType.ObservedProperty, id, odata);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>> GetDatastreamCollectionBySensor(string id, OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Datastream>>(EntityType.Datastream, EntityType.ObservedProperty, id, odata);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>> GetDatastreamCollectionByThing(string id, OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Datastream>>(EntityType.Datastream, EntityType.Thing, id, odata);
        }

        public async Task<Response<Sensor>> GetSensor(string id, OdataQuery odata = null)
        {
            return await Get<Sensor>(EntityType.Sensor, id, odata);
        }

        public async Task<Response<SensorThingsCollection<Sensor>>> GetSensorCollection(OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Sensor>>(EntityType.Sensor, odata);
        }

        public async Task<Response<Sensor>> GetSensorByDatastream(string id, OdataQuery odata = null)
        {
            return await Get<Sensor>(EntityType.Sensor,EntityType.Datastream, id, odata);
        }

        public async Task<Response<ObservedProperty>> GetObservedProperty(string id, OdataQuery odata = null)
        {
            return await Get<ObservedProperty>(EntityType.ObservedProperty, id, odata);
        }

        public async Task<Response<SensorThingsCollection<ObservedProperty>>> GetObservedPropertyCollection(OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<ObservedProperty>>(EntityType.ObservedProperty, odata);
        }

        public async Task<Response<ObservedProperty>> GetObservedPropertyByDatastream(string id, OdataQuery odata = null)
        {
            return await Get<ObservedProperty>(EntityType.ObservedProperty, EntityType.Datastream, id, odata);
        }

        public async Task<Response<Observation>> GetObservation(string id, OdataQuery odata = null)
        {
            return await Get<Observation>(EntityType.Observation, id, odata);
        }

        public async Task<Response<SensorThingsCollection<Observation>>> GetObservationCollection(OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Observation>>(EntityType.Observation, odata);
        }

        public async Task<Response<SensorThingsCollection<Observation>>> GetObservationCollectionByFeatureOfInterest(string id, OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Observation>>(EntityType.Observation, EntityType.FeatureOfInterest, id, odata);
        }

        public async Task<Response<SensorThingsCollection<Observation>>> GetObservationCollectionByDatastream(string id, OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<Observation>>(EntityType.Observation, EntityType.Datastream, id, odata);
        }

        public async Task<Response<FeatureOfInterest>> GetFeatureOfInterest(string id, OdataQuery odata = null)
        {
            return await Get<FeatureOfInterest>(EntityType.FeatureOfInterest, id, odata);
        }

        public async Task<Response<FeatureOfInterest>> GetFeatureOfInterestByObservation(string id, OdataQuery odata = null)
        {
            return await Get<FeatureOfInterest>(EntityType.FeatureOfInterest, EntityType.Observation, id, odata);
        }

        public async Task<Response<SensorThingsCollection<FeatureOfInterest>>> GetFeatureOfInterestCollection(OdataQuery odata = null)
        {
            return await Get<SensorThingsCollection<FeatureOfInterest>>(EntityType.FeatureOfInterest, odata);
        }

        public async Task<Response<Observation>> CreateObservation(Observation observation)
        {
            var url = _homedoc.GetUrlByEntityName("Observations");
            return await Http.PostJson<Observation>(url, observation);
        }

        private async Task<Response<T>> Get<T>(EntityType get, OdataQuery odata = null)
        {
            return await Get<T>(get, EntityType.None, null, odata);
        }

        private async Task<Response<T>> Get<T>(EntityType get, string id, OdataQuery odata = null)
        {
            return await Get<T>(get, EntityType.None, id, odata);
        }

        private async Task<Response<T>> Get<T>(EntityType get, EntityType by, string id, OdataQuery odata = null)
        {
            if (by != EntityType.None && string.IsNullOrEmpty(id))
            {
                throw new Exception("ID is required");
            }

            string url;
            var idString = string.IsNullOrEmpty(id) ? "" : $"({id})";

            if (by == EntityType.None)
            {
                url = $"{_homedoc.GetUrlByEntityName(get.GetString(true))}{idString}";
            }
            else
            {
                if (EntityMapping.GetByMapping.ContainsKey(get) && EntityMapping.GetByMapping[get].ContainsKey(by))
                {
                    url = $"{_homedoc.GetUrlByEntityName(by.GetString(true))}{idString}/{EntityMapping.GetByMapping[get][by]}";
                }
                else
                {
                    throw new Exception("Path does not exist");
                }
            }

            url = odata != null ? odata.AppendOdataQueryToUrl(url) : url;
            return await Http.GetJson<T>(url);
        }
    }
}
