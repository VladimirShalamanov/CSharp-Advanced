using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
            int[] bottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var cup = new Stack<int>(cups);
            var bottle = new Stack<int>(bottles);

            int wastedWater = 0;
            while (cup.Count != 0 && bottle.Count != 0)
            {
                if (cup.Peek() <= bottle.Peek())
                    wastedWater += bottle.Pop() - cup.Pop();
                else
                {
                    int leftCapacity = cup.Pop() - bottle.Pop();
                    cup.Push(leftCapacity);
                }
            }

            if (cup.Count == 0)
                Console.WriteLine($"Bottles: {string.Join(' ', bottle)}");
            else if (bottle.Count == 0)
                Console.WriteLine($"Cups: {string.Join(' ', cup)}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
