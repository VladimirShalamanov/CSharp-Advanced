using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            var book = new Dictionary<double, int>();

            foreach (var num in arr)
            {
                if (!book.ContainsKey(num))
                    book[num] = 0;
                book[num]++;
            }
            foreach (var a in book)
            {
                Console.WriteLine($"{a.Key} - {a.Value} times");
            }
        }
    }
}
