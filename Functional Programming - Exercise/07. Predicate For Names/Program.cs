using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            List<string> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> isLessOrEqual = x => x.Length <= length;
            list = list.FindAll(isLessOrEqual);
            foreach(var name in list)
                Console.WriteLine(name);
        }
    }
}
