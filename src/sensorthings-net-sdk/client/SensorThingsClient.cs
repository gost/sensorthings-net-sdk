using SensorThings.Core;

namespace SensorThings.Client
{
    public class SensorThingsClient
    {
        private HomeDocument homedoc;

        public SensorThingsClient(string Server)
        {
            this.Server = Server;
            homedoc = Http.GetJson<HomeDocument>(Server);
        }

        public string Server { get; set; }

        public FeatureOfInterest GetFeatureOfInterest()
        {
            var url = Server + "FeatureOfInterest";
            var foi = Http.GetJson<FeatureOfInterest>(url);
            return foi;
        }

        public SensorThingsCollection<FeatureOfInterest> GetFeatureOfInterestCollection()
        {
            var url = homedoc.GetUrlByEntity("FeaturesOfInterest");
            var fois = Http.GetJson<SensorThingsCollection<FeatureOfInterest>>(url);
            return fois;
        }

        public ObservedProperty GetObservedProperty()
        {
            var url = Server + "ObservedProperty";
            var observedProperty = Http.GetJson<ObservedProperty>(url);
            return observedProperty;
        }

        public SensorThingsCollection<ObservedProperty> GetObservedPropertyCollection()
        {
            var url = homedoc.GetUrlByEntity("ObservedProperties");
            var observedProperties = Http.GetJson<SensorThingsCollection<ObservedProperty>>(url);
            return observedProperties;
        }

        public Location GetLocation(int id)
        {
            var url = Server + $"Locations({id})";
            var location = Http.GetJson<Location>(url);
            return location;
        }

        public SensorThingsCollection<Location> GetLocationCollection()
        {
            var url = homedoc.GetUrlByEntity("Locations");
            var locations = Http.GetJson<SensorThingsCollection<Location>>(url);
            return locations;
        }

        public Observation GetObservation(int id)
        {
            var url = homedoc.GetUrlByEntity("Observations") + $"({id})";
            var observation = Http.GetJson<Observation>(url);
            return observation;
        }

        public SensorThingsCollection<Observation> GetObservationCollection()
        {
            var url = homedoc.GetUrlByEntity("Observations");
            var observations = Http.GetJson<SensorThingsCollection<Observation>>(url);
            return observations;
        }

        public HistoricalLocation GetHistoricalLocation(int id)
        {
            var url = homedoc.GetUrlByEntity("HistoricalLocations") + $"({id})";
            var historicalLocation = Http.GetJson<HistoricalLocation>(url);
            return historicalLocation;
        }

        public SensorThingsCollection<HistoricalLocation> GetHistoricalLocationsCollection()
        {
            var url = homedoc.GetUrlByEntity("HistoricalLocations");
            var historicalLocations = Http.GetJson<SensorThingsCollection<HistoricalLocation>>(url);
            return historicalLocations;
        }

        public Sensor GetSensor(int id)
        {
            var url = Server + $"Sensors({id})";
            var sensor = Http.GetJson<Sensor>(url);
            return sensor;
        }

        public SensorThingsCollection<Sensor> GetSensorCollection()
        {
            var url = homedoc.GetUrlByEntity("Sensors");
            var sensors = Http.GetJson<SensorThingsCollection<Sensor>>(url);
            return sensors;
        }

        public Datastream GetDatastream(int id)
        {
            var url = homedoc.GetUrlByEntity("Datastreams") + $"({id})";
            var datastream = Http.GetJson<Datastream>(url);
            return datastream;
        }


        public SensorThingsCollection<Datastream> GetDatastreamCollection(string url)
        {
            var datastreams = Http.GetJson<SensorThingsCollection<Datastream>>(url);
            return datastreams;
        }

        public SensorThingsCollection<Datastream> GetDatastreamCollection()
        {
            var url = homedoc.GetUrlByEntity("Datastreams");
            return GetDatastreamCollection(url);
        }

        public Thing GetThing(int id)
        {
            var url = homedoc.GetUrlByEntity("Things") + $"({id})";
            var thing = Http.GetJson<Thing>(url);
            return thing;
        }

        public SensorThingsCollection<Thing> GetThingCollection()
        {
            var url = homedoc.GetUrlByEntity("Things");
            var things = Http.GetJson<SensorThingsCollection<Thing>>(url);
            return things;
        }
    }
}
