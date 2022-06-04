using System;
using System.Collections;

namespace _08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue queue = new Queue();
            int count = 0;
            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                if (cmd == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count > 0)
                        {
                            count++;
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                        }
                    }
                    continue;
                }

                queue.Enqueue(cmd);
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
