using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var wardrope = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" -> ");
                string[] inputClothes = info[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                string color = info[0];

                if (!wardrope.ContainsKey(color))
                {
                    wardrope.Add(color, new Dictionary<string, int>());
                }

                Dictionary<string, int> clothes = wardrope[color];

                foreach (var cloth in inputClothes)
                {
                    if (!clothes.ContainsKey(cloth))
                        clothes.Add(cloth, 0);
                    clothes[cloth]++;
                }
            }

            string[] searchItem = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var color in wardrope)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    if (searchItem[0] == color.Key && searchItem[1] == cloth.Key)
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    else
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                }
            }
        }
    }
}
