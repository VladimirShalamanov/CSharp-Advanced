using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> listWater = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToList();
            List<double> listFlour = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToList();

            var bakeryProduct = new Dictionary<string, int>();

            Queue<double> queueWater = new Queue<double>(listWater);
            Stack<double> stackFlour = new Stack<double>(listFlour);


            string bakeProduct = string.Empty;
            double currWater = 0;
            double currFlour = 0;
            while (stackFlour.Any() && queueWater.Any())
            {
                currWater = queueWater.Dequeue();
                currFlour = stackFlour.Pop();
                double sum = currWater + currFlour;
                double firstPercent = (currWater * 100) / sum;
                double secondPercent = (currFlour * 100) / sum;

                if (firstPercent == 50 && secondPercent == 50)
                    bakeProduct = "Croissant";
                else if (firstPercent == 40 && secondPercent == 60)
                    bakeProduct = "Muffin";
                else if (firstPercent == 30 && secondPercent == 70)
                    bakeProduct = "Baguette";
                else if (firstPercent == 20 && secondPercent == 80)
                    bakeProduct = "Bagel";
                else
                {
                    if (currFlour > currWater)
                    {
                        double leftSum = currFlour - currWater;
                        currFlour -= leftSum;
                        bakeProduct = "Croissant";
                        stackFlour.Push(leftSum);
                    }
                }
                if (!bakeryProduct.ContainsKey(bakeProduct))
                    bakeryProduct.Add(bakeProduct, 0);
                bakeryProduct[bakeProduct]++;

            }

            foreach (var b in bakeryProduct.OrderByDescending(b => b.Value).ThenBy(b => b.Key))
            {
                Console.WriteLine($"{b.Key}: {b.Value}");
            }

            if (queueWater.Count == 0) Console.WriteLine("Water left: None");
            else Console.WriteLine($"Water left: {string.Join(", ", queueWater)}");

            if (stackFlour.Count == 0) Console.WriteLine("Flour left: None");
            else Console.WriteLine($"Flour left: {string.Join(", ", stackFlour)}");
        }
    }
}
