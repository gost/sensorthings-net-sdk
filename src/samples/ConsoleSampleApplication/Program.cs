using Newtonsoft.Json.Linq;
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
            // var server = "http://scratchpad.sensorup.com/OGCSensorThings/v1.0/";
            var server = "http://gost.geodan.nl/v1.0/";

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

            var datastream = client.GetDatastream(58);
            var observations = datastream.GetObservations();
            Console.WriteLine("Number if observations: " + observations.Count);

            Console.WriteLine("Sample with locations");
            var locations = client.GetLocationCollection();

            // Get location without using GeoJSON.NET (works only for points)
            var firstlocation = locations.Items[0];
            var feature = (JObject)firstlocation.Feature;
            var lon = feature.First.First.First.Value<double>();
            var lat = feature.First.First.Last.Value<double>();
            Console.WriteLine($"Location: {lon},{lat}");

            // if using GeoJSON.NET use something like:
            // var p = JsonConvert.DeserializeObject<Point>(feature.ToString());
            //  var ipoint = (GeographicPosition)p.Coordinates;
            // Console.WriteLine("Location: " + ipoint.Longitude + ", " + ipoint.Latitude);

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
