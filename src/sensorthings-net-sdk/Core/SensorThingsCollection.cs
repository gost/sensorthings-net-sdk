using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Newtonsoft.Json;

using SensorThings.Client;

namespace SensorThings.Core
{
    public class SensorThingsCollection<T> : INotifyPropertyChanged
    {
        private int _count;
        private string _nextLink;
        private ObservableCollection<T> _items;

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

        public bool HasNextPage()
        {
            return !string.IsNullOrEmpty(NextLink);
        }

        public async Task<Response<SensorThingsCollection<T>>> GetNextPage()
        {
            return HasNextPage() ? await Http.GetJson<SensorThingsCollection<T>>(NextLink): null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
