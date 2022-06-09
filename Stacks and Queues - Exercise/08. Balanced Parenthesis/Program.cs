using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Queue<char> queue = new Queue<char>(input);

            if (queue.Count % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            int count = 0;
            while (queue.Any())
            {
                var first = queue.Dequeue();
                var next = queue.Peek();

                if (first == '{')
                {
                    if (next == '}')
                    {
                        queue.Dequeue();
                        count = 0;
                        continue;
                    }
                    queue.Enqueue(first);
                }
                else if (first == '(')
                {
                    if (next == ')')
                    {
                        queue.Dequeue();
                        count = 0;
                        continue;
                    }
                    queue.Enqueue(first);
                }
                else if (first == '[')
                {
                    if (next == ']')
                    {
                        queue.Dequeue();
                        count = 0;
                        continue;
                    }
                    queue.Enqueue(first);
                }
                else
                {
                    queue.Enqueue(first);
                }
                count++;
                if (count == queue.Count)
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
