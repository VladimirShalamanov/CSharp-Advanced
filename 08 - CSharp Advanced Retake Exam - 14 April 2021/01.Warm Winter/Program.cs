using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> h = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> s = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var hatStack = new Stack<int>(h);
            var scarfqueue = new Queue<int>(s);
            var set = new List<int>();
            while (hatStack.Any() && scarfqueue.Any())
            {
                var hat = hatStack.Peek();
                var scarf = scarfqueue.Peek();
                if (hat > scarf)
                {
                    hatStack.Pop();
                    scarfqueue.Dequeue();
                    set.Add(hat + scarf);
                }
                else if (scarf > hat)
                {
                    hatStack.Pop();
                }
                else if (scarf == hat)
                {
                    scarfqueue.Dequeue();
                    hat++;
                    hatStack.Pop();
                    hatStack.Push(hat);
                }
            }
            Console.WriteLine($"The most expensive set is: {set.Max()}");
            Console.WriteLine(string.Join(' ', set));
        }
    }
}
