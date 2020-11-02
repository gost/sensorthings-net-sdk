namespace SensorThings.ODATA
{
    public class QueryTop : AbstractQuery<int>
    {
        public QueryTop(int top) : base("top", top) { }

        public override string GetQueryValueString()
        {
            return Value.ToString();
        }
    }
}
