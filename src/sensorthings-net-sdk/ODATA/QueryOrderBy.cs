using System.Collections.Generic;

using SensorThings.Extensions;

namespace SensorThings.OData
{
    public class QueryOrderBy : AbstractQuery<Dictionary<string, OrderType>>
    {
        public QueryOrderBy(Dictionary<string, OrderType> value) : base("orderby", value) {}

        public override string GetQueryValueString()
        {
            var valueString = "";
            foreach (var val in Value)
            {
                var prefix = string.IsNullOrEmpty(valueString) ? "" : ",";
                valueString = $"{valueString}{prefix}{val.Key} {val.Value.OrderTypeToString()}";
            }

            return valueString;
        }
    }
}
