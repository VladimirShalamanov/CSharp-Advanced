using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(input);

            string cmd;
            while ((cmd = Console.ReadLine().ToLower()) != "end")
            {
                var arr = cmd.Split(' ');
                var type = arr[0].ToLower();

                if (type == "add")
                {
                    int one = int.Parse(arr[1]);
                    int two = int.Parse(arr[2]);
                    stack.Push(one);
                    stack.Push(two);
                }
                else if (type == "remove")
                {
                    var countNums = int.Parse(arr[1]);
                    if (stack.Count < countNums)
                    {
                        continue;
                    }
                    for (int i = 0; i < countNums; i++)
                    {
                        stack.Pop();
                    }
                }
            }

            var sum = stack.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
