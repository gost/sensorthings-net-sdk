using System;
using System.Threading.Tasks;

using SensorThings.Core;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
namespace SensorThings.Client.Extensions {
    public static class CollectionExtensions {
        // ReSharper disable once MemberCanBePrivate.Global
        public static bool HasNextPage<T>(this SensorThingsCollection<T> collection) {
            return !string.IsNullOrEmpty(collection.NextLink);
        }

        public static async Task<SensorThingsCollection<T>> GetNextPage<T>(this SensorThingsCollection<T> collection) {
            var nextPage = HasNextPage(collection)
                ? await Http.GetJson<SensorThingsCollection<T>>(new Uri(collection.NextLink))
                : null;
            return nextPage?.Result;
        }
    }
}