namespace SensorThings.ODATA
{
    public class QueryFilter : AbstractQuery<string>
    {
        public QueryFilter(string value) : base("filter", value) {}

        public override string GetQueryValueString()
        {
            return Value;
        }
    }
}
