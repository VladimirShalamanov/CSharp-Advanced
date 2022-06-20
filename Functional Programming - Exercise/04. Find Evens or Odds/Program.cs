using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string type = Console.ReadLine();

            List<int> list = new List<int>();
            for (int i = nums[0]; i <= nums[1]; i++)
            {
                list.Add(i);
            }

            Predicate<int> predicate = null;
            if (type == "even")
                predicate = x => x % 2 == 0;
            else if (type == "odd")
                predicate = x => x % 2 != 0;
         
            Console.WriteLine(string.Join(" ", list.FindAll(predicate)));
        }
    }
}
