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
            var page = client.GetDatastreamCollection();
            var pagenumber = 1;
            while (page != null)
            {
                Console.WriteLine("---------------------------------------");
                WritePage(page);
                page = page.NextLink != null ? page.GetNextPage() : null;
                pagenumber++;
            }
            Console.WriteLine("End retrieving datastreams...");
            Console.WriteLine("Number of pages: " + pagenumber);
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
