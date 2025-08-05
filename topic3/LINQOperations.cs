using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CollectionDemo
{
    public static class LINQOperations
    {
        public static void Run()
        {
            Console.WriteLine("\n=== LINQ Operations ===");

            List<string> names = new() { "Alice", "Bob", "Charlie", "David", "Angela" };

            var filtered = names.Where(n => n.StartsWith("A")).ToList();
            Console.WriteLine("Names starting with A:");
            filtered.ForEach(Console.WriteLine);

            var nameLengths = names.Select(n => new { Name = n, Length = n.Length });
            Console.WriteLine("Name Lengths:");
            foreach (var item in nameLengths)
                Console.WriteLine($"{item.Name} - {item.Length}");

            var grouped = names.GroupBy(n => n.Length);
            Console.WriteLine("Grouped by length:");
            foreach (var group in grouped)
            {
                Console.WriteLine($"Length {group.Key}:");
                foreach (var name in group) Console.WriteLine($"- {name}");
            }
        }
    }
}
