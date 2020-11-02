namespace SensorThings.ODATA
{
    public class QueryCount : AbstractQuery<bool>
    {
        public QueryCount(bool count) : base("count", count){}

        public override string GetQueryValueString()
        {
            return Value.ToString().ToLower();
        }
    }
}
