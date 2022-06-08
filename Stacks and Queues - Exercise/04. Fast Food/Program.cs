using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] order = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(order);

            Console.WriteLine(queue.Max());

            for (int i = 0; i < order.Length; i++)
            {
                if (order[i] <= food)
                {
                    food -= queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', queue)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
