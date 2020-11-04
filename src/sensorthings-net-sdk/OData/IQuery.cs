namespace SensorThings.OData
{
    public interface IQuery
    {
        object GetValue();
        string GetQueryParam();
        string GetQueryValueString();        
    }
}
