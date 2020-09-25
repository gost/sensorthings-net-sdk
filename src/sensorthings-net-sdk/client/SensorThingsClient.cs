using System;
using System.Threading.Tasks;

using sensorthings.Core;

using SensorThings.Core;

using sensorthings.Extensions;
using sensorthings.ODATA;

namespace SensorThings.Client
{
    public class SensorThingsClient : ISensorThingsClient {
        private HomeDocument _homedoc;

        public string Server { get; set; }

        public SensorThingsClient(string server) {
            Server = server;
            Task.Run(async () => {
                    var response = await Http.GetJson<HomeDocument>(Server);
                    if (!response.Success) {
                        throw new Exception("Unable to get home document");
                    }

                    return _homedoc = response.Result;
                })
                .Wait();
        }

        public async Task<Response<Thing>> GetThing(string id, OdataQuery odata = null) {
            return await Get<Thing>(typeof(Thing), null, id, odata);
        }

        public async Task<Response<Thing>> GetThingByDatastream(string id, OdataQuery odata = null) {
            return await Get<Thing>(typeof(Thing), typeof(Datastream), id, odata);
        }

        public async Task<Response<Thing>> GetThingByHistoricalLocation(string id, OdataQuery odata = null) {
            return await Get<Thing>(typeof(Thing), typeof(HistoricalLocation), id, odata);
        }

        public async Task<Response<SensorThingsCollection<Thing>>> GetThingCollection(OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Thing>>(typeof(Thing), null, null, odata);
        }

        public async Task<Response<SensorThingsCollection<Thing>>> GetThingCollectionByLocation(
            string id, OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Thing>>(typeof(Thing), typeof(Location), id, odata);
        }

        public async Task<Response<Location>> GetLocation(string id, OdataQuery odata = null) {
            return await Get<Location>(typeof(Location), id, odata);
        }

        public async Task<Response<SensorThingsCollection<Location>>> GetLocationCollection(OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Location>>(typeof(Location), odata);
        }

        public async Task<Response<SensorThingsCollection<Location>>>
            GetLocationCollectionByHistoricalLocation(string id, OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Location>>(typeof(Location), typeof(HistoricalLocation), id, odata);
        }

        public async Task<Response<SensorThingsCollection<Location>>> GetLocationCollectionByThing(
            string id, OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Location>>(typeof(Location), typeof(Thing), id, odata);
        }

        public async Task<Response<HistoricalLocation>> GetHistoricalLocation(string id, OdataQuery odata = null) {
            return await Get<HistoricalLocation>(typeof(HistoricalLocation), id, odata);
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>>
            GetHistoricalLocationsCollection(OdataQuery odata = null) {
            return await Get<SensorThingsCollection<HistoricalLocation>>(typeof(HistoricalLocation), odata);
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>>
            GetHistoricalLocationsCollectionByLocation(string id, OdataQuery odata = null) {
            return await Get<SensorThingsCollection<HistoricalLocation>>(typeof(HistoricalLocation), typeof(Location),
                id, odata);
        }

        public async Task<Response<SensorThingsCollection<HistoricalLocation>>>
            GetHistoricalLocationsCollectionByThing(string id, OdataQuery odata = null) {
            return await Get<SensorThingsCollection<HistoricalLocation>>(typeof(HistoricalLocation), typeof(Thing), id,
                odata);
        }

        public async Task<Response<Datastream>> GetDatastream(string id, OdataQuery odata = null) {
            return await Get<Datastream>(typeof(Datastream), id, odata);
        }

        public async Task<Response<Datastream>> GetDatastreamByObservation(string id, OdataQuery odata = null) {
            return await Get<Datastream>(typeof(Datastream), typeof(Observation), id, odata);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>>
            GetDatastreamCollection(OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Datastream>>(typeof(Datastream), odata);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>>
            GetDatastreamCollectionByObservedProperty(string id, OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Datastream>>(typeof(Datastream), typeof(ObservedProperty), id,
                odata);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>>
            GetDatastreamCollectionBySensor(string id, OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Datastream>>(typeof(Datastream), typeof(ObservedProperty), id,
                odata);
        }

        public async Task<Response<SensorThingsCollection<Datastream>>>
            GetDatastreamCollectionByThing(string id, OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Datastream>>(typeof(Datastream), typeof(Thing), id, odata);
        }

        public async Task<Response<Sensor>> GetSensor(string id, OdataQuery odata = null) {
            return await Get<Sensor>(typeof(Sensor), id, odata);
        }

        public async Task<Response<SensorThingsCollection<Sensor>>> GetSensorCollection(OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Sensor>>(typeof(Sensor), odata);
        }

        public async Task<Response<Sensor>> GetSensorByDatastream(string id, OdataQuery odata = null) {
            return await Get<Sensor>(typeof(Sensor), typeof(Datastream), id, odata);
        }

        public async Task<Response<ObservedProperty>> GetObservedProperty(string id, OdataQuery odata = null) {
            return await Get<ObservedProperty>(typeof(ObservedProperty), id, odata);
        }

        public async Task<Response<SensorThingsCollection<ObservedProperty>>>
            GetObservedPropertyCollection(OdataQuery odata = null) {
            return await Get<SensorThingsCollection<ObservedProperty>>(typeof(ObservedProperty), odata);
        }

        public async Task<Response<ObservedProperty>> GetObservedPropertyByDatastream(
            string id, OdataQuery odata = null) {
            return await Get<ObservedProperty>(typeof(ObservedProperty), typeof(Datastream), id, odata);
        }

        public async Task<Response<Observation>> GetObservation(string id, OdataQuery odata = null) {
            return await Get<Observation>(typeof(Observation), id, odata);
        }

        public async Task<Response<SensorThingsCollection<Observation>>>
            GetObservationCollection(OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Observation>>(typeof(Observation), odata);
        }

        public async Task<Response<SensorThingsCollection<Observation>>>
            GetObservationCollectionByFeatureOfInterest(string id, OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Observation>>(typeof(Observation), typeof(FeatureOfInterest), id,
                odata);
        }

        public async Task<Response<SensorThingsCollection<Observation>>>
            GetObservationCollectionByDatastream(string id, OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Observation>>(typeof(Observation), typeof(Datastream), id, odata);
        }

        public async Task<Response<FeatureOfInterest>> GetFeatureOfInterest(string id, OdataQuery odata = null) {
            return await Get<FeatureOfInterest>(typeof(FeatureOfInterest), id, odata);
        }

        public async Task<Response<FeatureOfInterest>> GetFeatureOfInterestByObservation(
            string id, OdataQuery odata = null) {
            return await Get<FeatureOfInterest>(typeof(FeatureOfInterest), typeof(Observation), id, odata);
        }

        public async Task<Response<SensorThingsCollection<FeatureOfInterest>>>
            GetFeatureOfInterestCollection(OdataQuery odata = null) {
            return await Get<SensorThingsCollection<FeatureOfInterest>>(typeof(FeatureOfInterest), odata);
        }

        public async Task<Response<Observation>> CreateObservation(Observation observation) {
            var url = _homedoc.GetUrlByEntityName("Observations");
            return await Http.PostJson<Observation>(url, observation);
        }

        private async Task<Response<T>> Get<T>(Type get, OdataQuery odata = null) {
            return await Get<T>(get, null, null, odata);
        }

        private async Task<Response<T>> Get<T>(Type get, string id = null, OdataQuery odata = null) {
            return await Get<T>(get, null, id, odata);
        }

        private async Task<Response<T>> Get<T>(Type get, Type by = null, string id = null, OdataQuery odata = null) {
            if (by != null && string.IsNullOrEmpty(id)) {
                throw new Exception("ID is required");
            }

            string url;
            var idString = string.IsNullOrEmpty(id) ? "" : $"({id})";

            if (by == null) {
                url = $"{_homedoc.GetUrlByEntityName(get.GetString(true))}{idString}";
            } else {
                url = $"{_homedoc.GetUrlByEntityName(by.GetString(true))}{idString}/{get.GetString(by)}";
            }
            url = odata != null ? odata.AppendOdataQueryToUrl(url) : url;

            return await Http.GetJson<T>(url);
        }
    }
}
