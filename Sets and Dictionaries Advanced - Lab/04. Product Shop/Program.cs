using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, double>>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "Revision")
            {
                string[] arr = cmd.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string shop = arr[0];
                string product = arr[1];
                double price = double.Parse(arr[2]);

                if (!dict.ContainsKey(shop))
                    dict[shop] = new Dictionary<string, double>();
                if (!dict[shop].ContainsKey(product))
                    dict[shop].Add(product, 0);
                dict[shop][product] = price;
            }

            foreach (var shop in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
