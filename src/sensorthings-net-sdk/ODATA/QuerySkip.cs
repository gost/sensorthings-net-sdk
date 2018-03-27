namespace sensorthings.ODATA
{
    public class QuerySkip : AbstractQuery<int>
    {
        public QuerySkip(int skip) : base("skip", skip) { }
        
        public override string GetQueryValueString()
        {
            return Value.ToString();
        }
    }
}
