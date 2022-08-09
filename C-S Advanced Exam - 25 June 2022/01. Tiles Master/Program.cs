using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listWhite = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> listGrey = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var whiteQueue = new Stack<int>(listWhite);
            var greyQueue = new Queue<int>(listGrey);

            var location = new Dictionary<string, int>();

            while (whiteQueue.Any() && greyQueue.Any())
            {
                int white = whiteQueue.Pop();
                int grey = greyQueue.Dequeue();

                string s = string.Empty;

                if (white == grey)
                {
                    int sum = white + grey;
                    if (sum == 40)
                    {
                        s = "Sink";
                    }
                    else if (sum == 50)
                    {
                        s = "Oven";
                    }
                    else if (sum == 60)
                    {
                        s = "Countertop";
                    }
                    else if (sum == 70)
                    {
                        s = "Wall";
                    }
                    else
                    {
                        s = "Floor";
                    }
                    if (!location.ContainsKey(s))
                    {
                        location.Add(s, 0);
                    }
                    location[s]++;
                }
                else
                {
                    white /= 2;
                    whiteQueue.Push(white);
                    greyQueue.Enqueue(grey);
                }
            }

            if (!whiteQueue.Any()) Console.WriteLine("White tiles left: none");
            else Console.WriteLine($"White tiles left: {string.Join(", ", whiteQueue)}");
            if (!greyQueue.Any()) Console.WriteLine("Grey tiles left: none");
            else Console.WriteLine($"Grey tiles left: {string.Join(", ", greyQueue)}");

            foreach (var p in location.OrderByDescending(x => x.Value).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{p.Key}: {p.Value}");
            }
        }
    }
}
