using System;
using System.Threading.Tasks;

using Newtonsoft.Json;

using SensorThings.Client;
using SensorThings.Converters;
using SensorThings.OData;

namespace SensorThings.Core
{
    public class Observation : AbstractEntity
    {
        private DateTimeRange _phenomenonTime;
        private DateTimeRange _resultTime;
        private DateTimeRange _validTime;
        private object _resultQuality;
        private object _result;
        private object _parameters;
        private string _datastreamNavigationLink;
        private string _featureOfInterestNavigationLink;
        private Datastream _datastream;
        private FeatureOfInterest _featureOfInterest;

        [JsonProperty("phenomenonTime")]
        [JsonConverter(typeof(DateTimeRangeConverter))]
        public DateTimeRange PhenomenonTime
        {
            get => _phenomenonTime;
            set => SetProperty(ref _phenomenonTime, value);
        }

        [JsonProperty("resultTime")]
        [JsonConverter(typeof(DateTimeRangeConverter))]
        public DateTimeRange ResultTime
        {
            get => _resultTime;
            set => SetProperty(ref _resultTime, value);
        }

        [JsonProperty("validTime")]
        [JsonConverter(typeof(DateTimeRangeConverter))]
        public DateTimeRange ValidTime
        {
            get => _validTime;
            set => SetProperty(ref _validTime, value);
        }

        [JsonProperty("resultQuality")]
        public object ResultQuality
        {
            get => _resultQuality;
            set => SetProperty(ref _resultQuality, value);
        }

        [JsonProperty("result")]
        public object Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        [JsonProperty("parameters")]
        public object Parameters
        {
            get => _parameters;
            set => SetProperty(ref _parameters, value);
        }

        [JsonProperty("Datastream@iot.navigationLink")]
        public string DatastreamNavigationLink
        {
            get => _datastreamNavigationLink;
            set => SetProperty(ref _datastreamNavigationLink, value);
        }

        [JsonProperty("FeatureOfInterest@iot.navigationLink")]
        public string FeatureOfInterestNavigationLink
        {
            get => _featureOfInterestNavigationLink;
            set => SetProperty(ref _featureOfInterestNavigationLink, value);
        }

        [JsonProperty("Datastream")]
        public Datastream Datastream
        {
            get => _datastream;
            set => SetProperty(ref _datastream, value);
        }

        [JsonProperty("FeatureOfInterest")]
        public FeatureOfInterest FeatureOfInterest
        {
            get => _featureOfInterest;
            set => SetProperty(ref _featureOfInterest, value);
        }

        public async Task<Response<Datastream>> GetDatastream(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(DatastreamNavigationLink))
            {
                return await Http.GetJson<Datastream>(DatastreamNavigationLink);
            }

            return await client.GetDatastreamByObservation(Id, odata);
        }

        public async Task<Response<FeatureOfInterest>> GetFeatureOfInterest(SensorThingsClient client, OdataQuery odata = null)
        {
            if (!string.IsNullOrEmpty(FeatureOfInterestNavigationLink))
            {
                return await Http.GetJson<FeatureOfInterest>(FeatureOfInterestNavigationLink);
            }

            return await client.GetFeatureOfInterestByObservation(Id, odata);
        }

        public DateTime? GetPhenomenonTime(bool local = false)
        {
            var dt = PhenomenonTime.Start.Value;
            return local ? dt.ToLocalTime() : dt;            
        }
    }
}
