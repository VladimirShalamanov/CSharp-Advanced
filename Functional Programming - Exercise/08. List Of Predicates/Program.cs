using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToList();

            List<int> list = new List<int>();
            for (int num = 1; num <= n; num++)
            {
                var isDividers = true;
                foreach (var x in nums)
                {
                    Predicate<int> isNotDividers = x => num % x != 0;

                    if (isNotDividers(x))
                    {
                        isDividers = false;
                        break;
                    }
                }
                if (isDividers)
                    list.Add(num);
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
