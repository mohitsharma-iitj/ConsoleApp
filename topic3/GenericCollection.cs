using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;

namespace CollectionDemo
{
    public static class GenericCollections
    {
        public static void Run()
        {
            Console.WriteLine("=== Generic Collections ===");

            List<string> names = new() { "Alice", "Bob", "Charlie", "David", "Angela" };

            Console.WriteLine("Names:");
            names.ForEach(Console.WriteLine);


            Dictionary<string, int> ages = new()
            {
                { "Alice", 25 },
                { "Bob", 30 },
                { "Charlie", 22 }
            };
            Console.WriteLine("Ages:");
            foreach (var kv in ages)
            {
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            }
        }
    }
}
