using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using SensorThings.Converters;

namespace SensorThings.Core
{
    public class Observation : AbstractEntity
    {
        private DateTimeRange _phenomenonTime;
        private DateTime? _resultTime;
        private DateTimeRange _validTime;
        private object _resultQuality;
        private object _result;
        private IDictionary<string, object> _parameters;
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
        public DateTime? ResultTime
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
        public IDictionary<string, object> Parameters
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

        public DateTime? GetPhenomenonTime(bool local = false)
        {
            var dt = PhenomenonTime?.Start;
            return local ? dt?.ToLocalTime() : dt;            
        }
    }
}
