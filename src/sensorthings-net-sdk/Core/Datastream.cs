using System.Collections.ObjectModel;

using Newtonsoft.Json;

using SensorThings.Converters;

namespace SensorThings.Core
{
    public class Datastream : AbstractEntity
    {
        private string _name;
        private string _description;
        private string _observationType;
        private UnitOfMeasurement _unitOfMeasurement;
        private object _observedArea;
        private DateTimeRange _phenomenonTime;
        private DateTimeRange _resultTime;
        private string _observationsNavigationLink;
        private string _observedPropertyNavigationLink;
        private string _sensorNavigationLink;
        private string _thingNavigationLink;
        private Thing _thing;
        private Sensor _sensor;
        private ObservableCollection<Observation> _observations;
        private ObservedProperty _observedProperty;

        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        [JsonProperty("description")]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        [JsonProperty("observationType")]
        public string ObservationType
        {
            get => _observationType;
            set => SetProperty(ref _observationType, value);
        }

        [JsonProperty("unitOfMeasurement")]
        public UnitOfMeasurement UnitOfMeasurement
        {
            get => _unitOfMeasurement;
            set => SetProperty(ref _unitOfMeasurement, value);
        }

        [JsonProperty("observedArea")]
        public object ObservedArea
        {
            get => _observedArea;
            set => SetProperty(ref _observedArea, value);
        }

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

        [JsonProperty("Observations@iot.navigationLink")]
        public string ObservationsNavigationLink
        {
            get => _observationsNavigationLink;
            set => SetProperty(ref _observationsNavigationLink, value);
        }

        [JsonProperty("ObservedProperty@iot.navigationLink")]
        public string ObservedPropertyNavigationLink
        {
            get => _observedPropertyNavigationLink;
            set => SetProperty(ref _observedPropertyNavigationLink, value);
        }

        [JsonProperty("Sensor@iot.navigationLink")]
        public string SensorNavigationLink
        {
            get => _sensorNavigationLink;
            set => SetProperty(ref _sensorNavigationLink, value);
        }

        [JsonProperty("Thing@iot.navigationLink")]
        public string ThingNavigationLink
        {
            get => _thingNavigationLink;
            set => SetProperty(ref _thingNavigationLink, value);
        }

        [JsonProperty("Thing")]
        public Thing Thing
        {
            get => _thing;
            set => SetProperty(ref _thing, value);
        }

        [JsonProperty("Sensor")]
        public Sensor Sensor
        {
            get => _sensor;
            set => SetProperty(ref _sensor, value);
        }

        [JsonProperty("Observations")]
        public ObservableCollection<Observation> Observations
        {
            get => _observations;
            set => SetProperty(ref _observations, value);
        }

        [JsonProperty("ObservedProperty")]
        public ObservedProperty ObservedProperty
        {
            get => _observedProperty;
            set => SetProperty(ref _observedProperty, value);
        }
    }
}
