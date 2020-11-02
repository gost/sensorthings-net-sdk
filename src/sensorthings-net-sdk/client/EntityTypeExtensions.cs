using System;
using System.Collections.Generic;

using SensorThings.Core;

namespace sensorthings.Extensions {
    internal static class EntityTypeExtensions {
        private static readonly IDictionary<string, bool> Map =
            new Dictionary<string, bool> {
                { $"{nameof(Thing)}/{nameof(HistoricalLocation)}", false },
                { $"{nameof(Thing)}/{nameof(Datastream)}", false },
                { $"{nameof(Thing)}/{nameof(Location)}", true },
                { $"{nameof(Location)}/{nameof(HistoricalLocation)}", true },
                { $"{nameof(Location)}/{nameof(Thing)}", true },
                { $"{nameof(HistoricalLocation)}/{nameof(Thing)}", true },
                { $"{nameof(HistoricalLocation)}/{nameof(Location)}", true },
                { $"{nameof(Datastream)}/{nameof(ObservedProperty)}", true },
                { $"{nameof(Datastream)}/{nameof(Sensor)}", true },
                { $"{nameof(Datastream)}/{nameof(Thing)}", true },
                { $"{nameof(Datastream)}/{nameof(Observation)}", false },
                { $"{nameof(Sensor)}/{nameof(Datastream)}", false },
                { $"{nameof(ObservedProperty)}/{nameof(Datastream)}", false },
                { $"{nameof(Observation)}/{nameof(Datastream)}", true },
                { $"{nameof(Observation)}/{nameof(FeatureOfInterest)}", true },
                { $"{nameof(FeatureOfInterest)}/{nameof(Observation)}", false },
            };

        public static string GetString(this Type type, bool collection) {
            if (!type.IsSubclassOf(typeof(AbstractEntity))) {
                return "";
            }
            if (!collection) {
                return type.Name;
            }
            switch (type.Name) {
                case nameof(ObservedProperty):
                    return "ObservedProperties";
                case nameof(FeatureOfInterest):
                    return "FeaturesOfInterest";
                default:
                    return $"{type.Name}s";
            }
        }

        public static string GetString(this Type get, Type by) {
            var key = $"{get.Name}/{by.Name}";
            if (!Map.ContainsKey(key)) {
                throw new ArgumentException("Path does not exist");
            }
            return get.GetString(Map["key"]);
        }
    }
}
