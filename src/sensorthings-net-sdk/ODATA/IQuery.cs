namespace SensorThings.ODATA
{
    public interface IQuery
    {
        object GetValue();
        string GetQueryParam();
        string GetQueryValueString();        
    }
}
