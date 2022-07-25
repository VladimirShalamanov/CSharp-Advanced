using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumsList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> twoNumsList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var queueNums = new Queue<int>(firstNumsList);
            var stackNums = new Stack<int>(twoNumsList);

            double sum = 0;

            while (queueNums.Any() && stackNums.Any())
            {
                int firstItem = queueNums.Peek();
                int secondItem = stackNums.Pop();
                double s = firstItem + secondItem;
                if (s % 2 == 0)
                {
                    sum += s;
                    queueNums.Dequeue();
                }
                else
                {
                    queueNums.Enqueue(secondItem);
                }
            }

            if (queueNums.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (stackNums.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
