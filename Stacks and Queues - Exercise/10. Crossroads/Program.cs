using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();

            int totalCarsPassed = 0;

            string car;
            while ((car = Console.ReadLine()) != "END")
            {
                int newGreenLight = greenLight;
                int newFreeWindow = freeWindow;
                if (car == "green")
                {
                    while (newGreenLight > 0 && queue.Count != 0)
                    {
                        string currCar = queue.Dequeue();
                        newGreenLight -= currCar.Length;
                        if (newGreenLight >= 0)
                        {
                            totalCarsPassed++;
                        }
                        else
                        {
                            newFreeWindow += newGreenLight;
                            if (newFreeWindow < 0)
                            {
                                Console.WriteLine($"A crash happened!{Environment.NewLine}" +
                                                 $"{currCar} was hit at " +
                                                 $"{currCar[currCar.Length + newFreeWindow]}.");
                                return;
                            }
                            totalCarsPassed++;
                        }
                    }
                }
                else
                    queue.Enqueue(car);
            }

            Console.WriteLine($"Everyone is safe.{Environment.NewLine}" +
                              $"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
