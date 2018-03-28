using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace SensorThings.Core
{
    public abstract class AbstractEntity : INotifyPropertyChanged
    {
        private string _id;
        private string _selfLink;

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("@iot.id")]
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        [JsonProperty("@iot.selfLink")]
        public string SelfLink
        {
            get => _selfLink;
            set => SetProperty(ref _selfLink, value);
        }

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
