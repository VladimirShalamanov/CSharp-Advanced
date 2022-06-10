using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int moneyInSafe = int.Parse(Console.ReadLine());

            Stack<int> reload = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);

            int countReload = 0;
            while (locksQueue.Count != 0 && reload.Count != 0)
            {
                if (reload.Peek() <= locksQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                    Console.WriteLine("Ping!");

                reload.Pop();
                countReload++;
                if (countReload % gunBarrel == 0 && reload.Any())
                    Console.WriteLine("Reloading!");
            }

            if (locksQueue.Count == 0)
                Console.WriteLine($"{reload.Count} bullets left. Earned ${moneyInSafe - (price * countReload)}");
            else if (reload.Count == 0)
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
        }
    }
}
