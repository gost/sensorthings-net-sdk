using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace SensorThings.Core
{
    public class UnitOfMeasurement : INotifyPropertyChanged
    {
        private string _symbol;
        private string _name;
        private string _definition;

        [JsonProperty("symbol")]
        public string Symbol
        {
            get => _symbol;
            set => SetProperty(ref _symbol, value);
        }

        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        [JsonProperty("definition")]
        public string Definition
        {
            get => _definition;
            set => SetProperty(ref _definition, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
