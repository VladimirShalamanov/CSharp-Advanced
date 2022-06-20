using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int d = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = x => x % d != 0;

            Console.WriteLine(string.Join(" ", list.FindAll(isDivisible)));
        }
    }
}
