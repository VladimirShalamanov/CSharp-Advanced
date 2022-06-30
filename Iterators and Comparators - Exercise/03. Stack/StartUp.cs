using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                var tokens = cmd
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (tokens[0] == "Push")
                    stack.Push(tokens.Skip(1)
                        .Select(e => e.Split(",", StringSplitOptions.RemoveEmptyEntries).First())
                        .ToArray());
                else if (tokens[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }

            foreach (var el in stack)
            {
                Console.WriteLine(el);
            }
            foreach (var el in stack)
            {
                Console.WriteLine(el);
            }
        }
    }
}
