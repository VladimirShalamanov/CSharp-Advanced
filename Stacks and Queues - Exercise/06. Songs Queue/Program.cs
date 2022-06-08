using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ").ToArray();

            Queue<string> queue = new Queue<string>(songs);

            string cmd;
            while (true)
            {
                cmd = Console.ReadLine();

                if (cmd == "Play")
                {
                    queue.Dequeue();
                    if (queue.Count == 0)
                    {
                        Console.WriteLine("No more songs!");
                        return;

                    }
                }
                else if (cmd.StartsWith("Add"))
                {
                    int index = 4;
                    string song = cmd.Substring(index);

                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                        continue;
                    }
                    Console.WriteLine($"{song} is already contained!");
                }
                else if (cmd == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
            }
        }
    }
}
