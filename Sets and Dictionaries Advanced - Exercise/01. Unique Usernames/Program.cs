using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name;
                dict.Add(name = Console.ReadLine());
            }

            foreach (var name in dict)
            {
                Console.WriteLine(name);
            }
        }
    }
}
