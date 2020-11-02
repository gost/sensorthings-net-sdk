using System;
using System.Threading.Tasks;

using SensorThings.Core;
using SensorThings.Extensions;
using SensorThings.ODATA;

namespace SensorThings.Client {
    public class SensorThingsClient : ISensorThingsClient {
        private HomeDocument _homedoc;

        public SensorThingsClient(string server) {
            Task.Run(async () => {
                    var response = await Http.GetJson<HomeDocument>(server);
                    if (!response.Success) {
                        throw new Exception("Unable to get home document");
                    }

                    return _homedoc = response.Result;
                })
                .Wait();
        }

        public async Task<Response<Thing>> GetThing(string id, OdataQuery odata = null) {
            return await Get<Thing>(typeof(Thing), id, odata);
        }

        public async Task<Response<Thing>> GetThingByDatastream(string id, OdataQuery odata = null) {
            return await Get<Thing>(typeof(Thing), typeof(Datastream), id, odata);
        }

        public async Task<Response<Thing>> GetThingByHistoricalLocation(string id, OdataQuery odata = null) {
            return await Get<Thing>(typeof(Thing), typeof(HistoricalLocation), id, odata);
        }

        public async Task<Response<SensorThingsCollection<Thing>>> GetThingCollection(OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Thing>>(typeof(Thing), null, odata);
        }

        public async Task<Response<SensorThingsCollection<Thing>>> GetThingCollectionByLocation(
            string id, OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Thing>>(typeof(Thing), typeof(Location), id, odata);
        }

        public async Task<Response<Location>> GetLocation(string id, OdataQuery odata = null) {
            return await Get<Location>(typeof(Location), id, odata);
        }

        public async Task<Response<SensorThingsCollection<Location>>> GetLocationCollection(OdataQuery odata = null) {
            return await Get<SensorThingsCollection<Location>>(typeof(Location), null, odata);
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
            return await Get<SensorThingsCollection<HistoricalLocation>>(typeof(HistoricalLocation), null, odata);
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
            return await Get<SensorThingsCollection<Datastream>>(typeof(Datastream), null, odata);
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
            return await Get<SensorThingsCollection<Sensor>>(typeof(Sensor), null, odata);
        }

        public async Task<Response<Sensor>> GetSensorByDatastream(string id, OdataQuery odata = null) {
            return await Get<Sensor>(typeof(Sensor), typeof(Datastream), id, odata);
        }

        public async Task<Response<ObservedProperty>> GetObservedProperty(string id, OdataQuery odata = null) {
            return await Get<ObservedProperty>(typeof(ObservedProperty), id, odata);
        }

        public async Task<Response<SensorThingsCollection<ObservedProperty>>>
            GetObservedPropertyCollection(OdataQuery odata = null) {
            return await Get<SensorThingsCollection<ObservedProperty>>(typeof(ObservedProperty), null, odata);
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
            return await Get<SensorThingsCollection<Observation>>(typeof(Observation), null, odata);
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
            return await Get<SensorThingsCollection<FeatureOfInterest>>(typeof(FeatureOfInterest), null, odata);
        }

        public async Task<Response<Observation>> CreateObservation(Observation observation) {
            var url = _homedoc.GetUrlByEntityName("Observations");
            return await Http.PostJson(url, observation);
        }

        private async Task<Response<T>> Get<T>(Type get, string id, OdataQuery odata) {
            var idString = string.IsNullOrEmpty(id) ? "" : $"({id})";

            var url = $"{_homedoc.GetUrlByEntityName(get.GetString(true))}{idString}";
            url = odata != null ? odata.AppendOdataQueryToUrl(url) : url;

            return await Http.GetJson<T>(url);
        }

        private async Task<Response<T>> Get<T>(Type get, Type by, string id, OdataQuery odata) {
            if (by == null) {
                throw new ArgumentNullException(nameof(by));
            }
            if (string.IsNullOrEmpty(id)) {
                throw new ArgumentException("ID is required", nameof(id));
            }
            var url = $"{_homedoc.GetUrlByEntityName(by.GetString(true))}({id})/{get.GetString(by)}";
            url = odata != null ? odata.AppendOdataQueryToUrl(url) : url;

            return await Http.GetJson<T>(url);
        }
    }
}
