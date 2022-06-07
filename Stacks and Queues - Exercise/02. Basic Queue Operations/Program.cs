using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < arr[0]; i++)
            {
                queue.Enqueue(nums[i]);
            }

            for (int i = 0; i < arr[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(arr[2]))
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine(queue.Count > 0 ? queue.Min() : 0);
            }
        }
    }
}
