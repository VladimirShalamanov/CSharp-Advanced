using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listGuest = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> listFood = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var guestQueue = new Queue<int>(listGuest);
            var foodStack = new Stack<int>(listFood);
            int wastedGramsOfFood = 0;

            while (guestQueue.Any() && foodStack.Any())
            {
                var guest = guestQueue.Dequeue();
                var food = foodStack.Pop();

                if (food >= guest)
                {
                    food -= guest;
                    wastedGramsOfFood += food;
                }
                else if (guest > food)
                {
                    guest -= food;
                    while (guest > 0)
                    {
                        if (foodStack.Count > 0)
                        {
                            food = foodStack.Pop();
                            if (food >= guest)
                            {
                                food -= guest;
                                wastedGramsOfFood += food;
                                guest = 0;
                            }
                            else if (guest > food)
                            {
                                guest -= food;
                            }
                        }
                        else break;
                    }
                }
            }

            if (foodStack.Count > 0) Console.WriteLine($"Plates: {string.Join(' ', foodStack)}");
            else if (guestQueue.Count > 0) Console.WriteLine($"Guests: {string.Join(' ', guestQueue)}");
            Console.WriteLine($"Wasted grams of food: {wastedGramsOfFood}");
        }
    }
}
