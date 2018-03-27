using System;

namespace sensorthings.Extensions
{
    public static class EntityTypeExtensions
    {
        public static string GetString(this EntityType entityType, bool collection)
        {
            switch (entityType)
            {
                case EntityType.None:
                    return "";
                case EntityType.Thing:
                    return collection ? "Things" : "Thing";
                case EntityType.Location:
                    return collection ? "Locations" : "Location";
                case EntityType.HistoricalLocation:
                    return collection ? "HistoricalLocations" : "HistoricalLocation";
                case EntityType.Datastream:
                    return collection ? "Datastreams" : "Datastream";
                case EntityType.Sensor:
                    return collection ? "Sensors" : "Sensor";
                case EntityType.ObservedProperty:
                    return collection ? "ObservedProperties" : "ObservedProperty";
                case EntityType.Observation:
                    return collection ? "Observations" : "Observation";
                case EntityType.FeatureOfInterest:
                    return collection ? "FeaturesOfInterest" : "FeatureOfInterest";
                default:
                    throw new ArgumentOutOfRangeException(nameof(entityType), entityType, null);
            }
        }
    }
}
