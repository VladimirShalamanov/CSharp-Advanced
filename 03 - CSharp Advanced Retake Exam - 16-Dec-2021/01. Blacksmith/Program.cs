using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listSteel = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var listCarbon = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var steelQueue = new Queue<int>(listSteel);
            var carbonStack = new Stack<int>(listCarbon);

            var swords = new Dictionary<string, int>();

            while (steelQueue.Any() && carbonStack.Any())
            {
                int steel = steelQueue.Dequeue();
                int carbon = carbonStack.Pop();
                int sum = steel + carbon;
                string sword = string.Empty;
                if (sum == 70)
                    sword = "Gladius";
                else if (sum == 80)
                    sword = "Shamshir";
                else if (sum == 90)
                    sword = "Katana";
                else if (sum == 110)
                    sword = "Sabre";
                else if (sum == 150)
                    sword = "Broadsword";
                else
                {
                    carbon += 5;
                    carbonStack.Push(carbon);
                    continue;
                }
                if (!swords.ContainsKey(sword))
                    swords.Add(sword, 0);
                swords[sword]++;
            }

            if (swords.Count > 0) Console.WriteLine($"You have forged {swords.Values.Sum()} swords.");
            else Console.WriteLine($"You did not have enough resources to forge a sword.");
            if (steelQueue.Count == 0) Console.WriteLine("Steel left: none");
            else Console.WriteLine($"Steel left: {string.Join(", ", steelQueue)}");
            if (carbonStack.Count == 0) Console.WriteLine("Carbon left: none");
            else Console.WriteLine($"Carbon left: {string.Join(", ", carbonStack)}");
            if (swords.Count > 0) foreach (var s in swords.OrderBy(s => s.Key)) Console.WriteLine($"{s.Key}: {s.Value}");
        }
    }
}
