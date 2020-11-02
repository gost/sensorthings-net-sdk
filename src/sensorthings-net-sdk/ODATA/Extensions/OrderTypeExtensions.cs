using System;

using SensorThings.ODATA;

namespace SensorThings.Extensions
{
    public static class OrderTypeExtensions
    {
        public static string OrderTypeToString(this OrderType order)
        {
            switch (order)
            {
                case OrderType.Ascending:
                {
                    return "asc";
                }
                case OrderType.Descending:
                {
                    return "desc";
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(order), order, null);
            }
        }
    }
}
