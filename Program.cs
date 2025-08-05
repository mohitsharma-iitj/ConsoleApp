using System;
using System.Collections;

namespace CollectionDemo
{
    class Program
    {
        static void Main()
        {
            ArrayList al = new ArrayList();
            al.Add(1);
            //al.Add("Hello");
            al.Add(5);

            foreach (var item in al)
            {
                Console.WriteLine(item);
            }

            int[] numbers = { 5, 10, 15, 20, 25 };
            var result = numbers.Where(n => n > 10).ToArray();

            foreach (var n in result)
            {
                Console.WriteLine(n); // Output: 15, 20, 25
            }

            //GenericCollections.Run();
            //LINQOperations.Run();
            CustomCollections.Run();
        }
    }
}
