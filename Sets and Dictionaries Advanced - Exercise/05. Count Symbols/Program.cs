using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var dict = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (!dict.ContainsKey(c))
                    dict[c] = 0;
                dict[c]++;
            }
            foreach (var ch in dict)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
