namespace SensorThings.OData
{
    public class QueryExpand : AbstractQuery<Expand[]>
    {
        public QueryExpand(Expand[] value) : base("expand", value) {}

        public override string GetQueryValueString()
        {
            var valueString = "";
            foreach (var val in Value)
            {
                var prefix = string.IsNullOrEmpty(valueString) ? "" : ",";
                valueString = $"{valueString}{prefix}{val.GetExpandString()}";
            }

            return valueString;
        }
    }
}
