using System.Collections.Generic;
using sensorthings.Extensions;

namespace sensorthings.Core
{
    public class EntityMapping
    {
        public static Dictionary<EntityType, Dictionary<EntityType, string>> GetByMapping = new Dictionary<EntityType, Dictionary<EntityType, string>>{
            {
                EntityType.Thing, new Dictionary<EntityType, string>
                {
                    { EntityType.HistoricalLocation, EntityType.Thing.GetString(false) },
                    { EntityType.Datastream, EntityType.Thing.GetString(false) },
                    { EntityType.Location, EntityType.Thing.GetString(true) },
                }
            },
            {
                EntityType.Location, new Dictionary<EntityType, string>
                {
                    { EntityType.HistoricalLocation, EntityType.Location.GetString(true) },
                    { EntityType.Thing, EntityType.Location.GetString(true) }
                }
            },
            {
                EntityType.HistoricalLocation, new Dictionary<EntityType, string>
                {
                    { EntityType.Thing, EntityType.HistoricalLocation.GetString(true) },
                    { EntityType.Location, EntityType.HistoricalLocation.GetString(true) }
                }
            },
            {
                EntityType.Datastream, new Dictionary<EntityType, string>
                {
                    { EntityType.ObservedProperty, EntityType.Datastream.GetString(true) },
                    { EntityType.Sensor, EntityType.Datastream.GetString(true) },
                    { EntityType.Thing, EntityType.Datastream.GetString(true) },
                    { EntityType.Observation, EntityType.Datastream.GetString(false) }
                }
            },
            {
                EntityType.Sensor, new Dictionary<EntityType, string>
                {
                    { EntityType.Datastream, EntityType.Sensor.GetString(false) }
                }
            },
            {
                EntityType.ObservedProperty, new Dictionary<EntityType, string>
                {
                    { EntityType.Datastream, EntityType.ObservedProperty.GetString(false) }
                }
            },
            {
                EntityType.Observation, new Dictionary<EntityType, string>
                {
                    { EntityType.Datastream, EntityType.Observation.GetString(true) },
                    { EntityType.FeatureOfInterest, EntityType.Observation.GetString(true) },
                }
            },
            {
                EntityType.FeatureOfInterest, new Dictionary<EntityType, string>
                {
                    { EntityType.Observation, EntityType.FeatureOfInterest.GetString(false) }
                }
            }
        };
    }
}
