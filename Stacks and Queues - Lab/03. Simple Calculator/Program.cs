using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray()
                .Reverse();

            var stack = new Stack<string>(input);

            int currStart = int.Parse(stack.Pop());
            int sum = currStart;
            while (stack.Count > 0)
            {
                string sym = stack.Pop();
                int num = int.Parse(stack.Pop());
                if (sym == "+")
                {
                    sum += num;
                }
                else if (sym == "-")
                {
                    sum -= num;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
