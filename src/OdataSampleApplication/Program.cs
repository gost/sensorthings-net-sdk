using sensorthings.ODATA;
using SensorThings.Client;
using System;
using System.Collections.Generic;

namespace OdataSampleApplication
{
    class Program
    {
        public static SensorThingsClient Client = new SensorThingsClient("https://gost.geodan.nl/v1.0");
        
        static void Main(string[] args)
        {
            GetDatastreamsOdataExample();
            Console.WriteLine("Program ends... Press a key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Get Datastreams where name contains temperature including Sensor and ObservedProperty 
        /// and the 5 latest observations with a result of 15 or higher
        /// select only id and name for datastreams and id, result and phenomenonTime for the observations
        /// </summary>
        public static async void GetDatastreamsOdataExample()
        {
            var odataQueryObservations = new OdataQuery
            {
                QuerySelect = new QuerySelect(new[] { "id", "result", "phenomenonTime" }),
                QueryTop = new QueryTop(5),
                QueryFilter = new QueryFilter("result ge 15"),
                QueryOrderBy = new QueryOrderBy(new Dictionary<string, OrderType> { { "phenomenonTime", OrderType.Descending } })
            };

            var odataQuery = new OdataQuery
            {
                QuerySelect = new QuerySelect(new[] { "id", "name" }),
                QueryFilter = new QueryFilter("contains(name,'temperature')"),
                QueryExpand = new QueryExpand(new[]{
                    new Expand(new[] {"Sensor"}),
                    new Expand(new[] {"ObservedProperty"}),
                    new Expand(new[] {"Observations"}, odataQueryObservations)
                })
            };

            var datastreamsResponse = await Client.GetDatastreamCollection(odataQuery);
            if (datastreamsResponse.Success)
            {
                var datastreams = datastreamsResponse.Result;
                foreach (var datastream in datastreams.Items)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"Datastream: {datastream.Name}");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"Sensor: {datastream.Sensor.Name}");
                    Console.WriteLine($"ObservedProperty: {datastream.ObservedProperty.Name}");

                    foreach (var obs in datastream.Observations)
                    {
                        Console.WriteLine($"{obs.PhenomenonTime.Start} - {obs.Result}");
                    }

                    Console.WriteLine("");
                }
            }
        }
    }
}
