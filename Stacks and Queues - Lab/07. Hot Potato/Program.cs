using System;
using System.Collections;
using System.Linq;

namespace _07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split(' ').ToArray();
            int n = int.Parse(Console.ReadLine());
            Queue queue = new Queue(kids);

            while (queue.Count != 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i == n)
                    {
                        Console.WriteLine("Removed " + queue.Dequeue());
                        break;
                    }
                    var kid = queue.Peek();
                    queue.Dequeue();
                    queue.Enqueue(kid);
                }
            }

            Console.WriteLine("Last is " + queue.Peek());
        }
    }
}

