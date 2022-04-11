using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;



namespace Lab09_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../data.json";
            string readFile = File.ReadAllText(path);
            FeatureCollection places = JsonConvert.DeserializeObject<FeatureCollection>(readFile);
            AllNeighbor(places);
            FilterNeighborDoNotHaveAnyNames(places);
            RemoveTheDuplicates(places);
            ConsolidateAllIntoOneSingleQuery(places);
            LINQ(places);

        }

        // Output all of the neighborhoods in this data list (Final Total: 147 neighborhoods)
        static void AllNeighbor(FeatureCollection fc)
        {
            var query = from Feature in fc.Features
                        select Feature.Properties.Neighborhood;
            Console.WriteLine("Output all of the neighborhoods in this data list");
            int count = 1;
            foreach (var item in query)
            {
                Console.WriteLine($"{count}. {item}");
                count++;
            }
        }
        // Filter out all the neighborhoods that do not have any names (Final Total: 143)
        static void FilterNeighborDoNotHaveAnyNames(FeatureCollection fc)
        {
            var query = from Features in fc.Features
                        where Features.Properties.Neighborhood != ""
                        select Features.Properties.Neighborhood;
            int count = 1;
            foreach (var item in query)
            {
                Console.WriteLine($"{count}. {item}");
                count++;
            }
        }
        // Remove the duplicates (Final Total: 39 neighborhoods)
        static void RemoveTheDuplicates(FeatureCollection fc)
        {
            var query = (from Feature in fc.Features
                        where Feature.Properties.Neighborhood != ""
                        select Feature.Properties.Neighborhood).Distinct();
            int count = 1;
            foreach (var item in query)
            {
                Console.WriteLine($"{count}. {item}");
                count++;
            }
        }
        // Rewrite the queries from above and consolidate all into one single query.
        static public void ConsolidateAllIntoOneSingleQuery(FeatureCollection fc)
        {
            var query = (from Feature in fc.Features
                         where Feature.Properties.Neighborhood != ""
                         select Feature.Properties.Neighborhood).Distinct();
            int count = 1;
            foreach (var item in query)
            {
                Console.WriteLine($"{count}. {item}");
                count++;
            }
        }
        // Rewrite at least one of these questions only using the opposing method
        static void LINQ(FeatureCollection fc)
        {
            var query = fc.Features
                            .Select(x => new { x.Properties.Neighborhood })
                            .Where(x => x.Neighborhood != "")
                            .Distinct();
            int count = 1;

            foreach (var item in query)
            {
                Console.WriteLine($"{count}. {item.Neighborhood}");
                count++;
            }
        }
    }


}
