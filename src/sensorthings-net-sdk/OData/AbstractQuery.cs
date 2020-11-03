namespace SensorThings.OData
{
    public abstract class AbstractQuery<T> : IQuery
    {
        private readonly string _queryParam;

        public T Value { get; set; }
        public abstract string GetQueryValueString();        

        protected AbstractQuery(string queryParam, T value)
        {
            Value = value;
            _queryParam = queryParam;
        }

        public string GetQueryParam()
        {
            return _queryParam;
        }

        object IQuery.GetValue()
        {
            return Value;
        }
    }
}
