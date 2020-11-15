using System;

using SensorThings.Core;

namespace SensorThings.Extensions {
    public static class EntityTypeExtensions {
        public static string GetString(this Type type, bool isPlural) {
            if (!type.IsSubclassOf(typeof(AbstractEntity))) {
                return String.Empty;
            }
            if (!isPlural) {
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
    }
}
