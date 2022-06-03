using System;
using System.Collections;

namespace _06._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            string cmd;
            while (true)
            {
                cmd = Console.ReadLine();
                if (cmd == "Paid")
                {
                    foreach (var name in queue)
                    {
                        Console.WriteLine(name);
                    }
                    queue.Clear();
                    continue;
                }
                if (cmd == "End")
                {
                    Console.WriteLine($"{queue.Count} people remaining.");
                }
                queue.Enqueue(cmd);
            }
        }
    }
}
