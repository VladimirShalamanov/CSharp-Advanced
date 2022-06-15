using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var one = new HashSet<int>();
            var two = new HashSet<int>();

            for (int i = 0; i < arr[0]; i++)
                one.Add(int.Parse(Console.ReadLine()));
            for (int i = 0; i < arr[1]; i++)
                two.Add(int.Parse(Console.ReadLine()));
            one.IntersectWith(two);
            Console.WriteLine(string.Join(" ", one));
        }
    }
}
