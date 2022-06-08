using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rack = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothes);

            int countRacks = 0;
            int capacity = 0;
            for (int i = 0; i < clothes.Length; i++)
            {
                capacity += stack.Peek();
                if (capacity == rack)
                {
                    countRacks++;
                    capacity = 0;
                    stack.Pop();
                    continue;
                }
                else if (capacity > rack)
                {
                    countRacks++;
                    capacity = 0;
                    capacity += stack.Pop();
                    continue;
                }

                stack.Pop();
            }

            if (capacity > 0 && stack.Count == 0)
            {
                countRacks++;
            }

            Console.WriteLine(countRacks);
        }
    }
}
