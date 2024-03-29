﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < arr[0]; i++)
            {
                stack.Push(nums[i]);
            }
            for (int i = 0; i < arr[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(arr[2]))
            {
                Console.WriteLine("true");
            }
            else if (!stack.Contains(arr[2]) && stack.Count > 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
