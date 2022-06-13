using System;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .ToArray();
            if (nums.Length > 3)
            {
                for (int i = 0; i < 3; i++)
                    Console.Write(nums[i] + " ");
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                    Console.Write(nums[i] + " ");
            }
        }
    }
}

