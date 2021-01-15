using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Newtonsoft.Json;

namespace SensorThings.Core
{
    public class SensorThingsCollection<T> : INotifyPropertyChanged
    {
        private int _count;
        private string _nextLink;
        private ObservableCollection<T> _items;

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonProperty("@iot.count")]
        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        [JsonProperty("@iot.nextLink")]
        public string NextLink
        {
            get => _nextLink;
            set => SetProperty(ref _nextLink, value);
        }

        [JsonProperty("value")]
        public ObservableCollection<T> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        protected bool SetProperty<TS>(ref TS storage, TS value, [CallerMemberName] string propertyName = null)
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
