using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace sensorthings.Core
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ObservationType
    {
        [EnumMember(Value = "http://www.opengis.net/def/observationType/OGC-OM/2.0/OM_Measurement")]
        Measurement, // double

        [EnumMember(Value = "http://www.opengis.net/def/observationType/OGC-OM/2.0/OM_CountObservation")]
        CountObservation, // int

        [EnumMember(Value = "http://www.opengis.net/def/observationType/OGC-OM/2.0/OM_Observation")]
        Observation, // any

        [EnumMember(Value = "http://www.opengis.net/def/observationType/OGC-OM/2.0/OM_ThruthObservation")]
        ThruthObservation, // bool

        [EnumMember(Value = "http://www.opengis.net/def/observationType/OGC-OM/2.0/OM_CategoryObservation")]
        CategoryObservation // Uri
    }
}
