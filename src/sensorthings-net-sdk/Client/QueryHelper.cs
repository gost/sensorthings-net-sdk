using System;

using SensorThings.OData;

namespace SensorThings.Client {
    // ReSharper disable UnusedType.Global
    // ReSharper disable UnusedMember.Global
    // ReSharper disable MemberCanBePrivate.Global
    public static class QueryHelper {
        public static OdataQuery Empty() =>
            new OdataQuery();
        
        public static OdataQuery TopN(int top) =>
            TopN(new OdataQuery(), top);

        public static OdataQuery AttributeFilter(string key, string value) =>
            AttributeFilter(new OdataQuery(), key, value);

        public static OdataQuery PropertyFilter(string key, string value) =>
            PropertyFilter(new OdataQuery(), key, value);

        /* ++++++++++ extensions ++++++++++ */
        // TODO append filter (using OR/AND) if already exists
        
        public static OdataQuery TopN(this OdataQuery query, int top) {
            _ = query ?? throw new ArgumentNullException(nameof(query));

            query.QueryTop = new QueryTop(top);
            return query;
        }

        public static OdataQuery AttributeFilter(this OdataQuery query, string key, string value) {
            _ = query ?? throw new ArgumentNullException(nameof(query));

            query.QueryFilter = new QueryFilter($"{key} eq '{value}'");
            return query;
        }
        
        public static OdataQuery PropertyFilter(this OdataQuery query, string key, string value) =>
            AttributeFilter(query, $"properties/{key}", value);
    }
}
