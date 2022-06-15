using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] name = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < name.Length; x++)
                    dict.Add(name[x]);
            }
            Console.WriteLine(string.Join(" ", dict.OrderBy(x => x)));
        }
    }
}
