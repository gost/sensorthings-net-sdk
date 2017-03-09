using SensorThings.Client;
using SensorThings.Core;
using System;

namespace ConsoleSampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sample console app for SensorThings API client");
            var server = "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/";
            var client = new SensorThingsClient(server);

            Console.WriteLine("Retrieve all paged datastreams...");
            var datastreams = client.GetDatastreamCollection();
            WritePage(datastreams);
            var nextpage = datastreams.GetNextPage();
            var page = 1;
            while (nextpage != null)
            {
                Console.WriteLine("---------------------------------------");
                WritePage(nextpage);
                nextpage = nextpage.NextLink != null ? nextpage.GetNextPage() : null;
                page++;
            }
            Console.WriteLine("End retrieving datastreams...");
            Console.WriteLine("Number of pages: " + page);
            Console.ReadKey();
        }

        static void WritePage(SensorThingsCollection<Datastream> datastreams) {
            foreach (var datastream in datastreams.Items)
            {
                Console.WriteLine(datastream.Id + ": " + datastream.Description);
            }
        }
    }
}
