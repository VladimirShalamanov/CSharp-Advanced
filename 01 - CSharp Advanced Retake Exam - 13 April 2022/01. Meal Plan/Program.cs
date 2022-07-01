using System;
using System.Collections.Generic;
using System.Linq;

namespace P01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> maxCal = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            Stack<int> calories = new Stack<int>(maxCal);
            Queue<string> meals = new Queue<string>(input);


            string currMeal = string.Empty;
            int currMealCal = 0;
            if (meals.Any())
            {
                currMeal = meals.Dequeue();
                currMealCal = GetCurrMealCal(currMeal);
            }
            else
            {
                return;
            }

            int currDayCal = 0;
            while (calories.Any())
            {
                currDayCal = calories.Pop();
                if (currDayCal == 0)
                {
                    break;
                }
                if (currDayCal > currMealCal)
                {
                    currDayCal -= currMealCal;
                    calories.Push(currDayCal);
                    if (meals.Any())
                    {
                        currMeal = meals.Dequeue();
                        currMealCal = GetCurrMealCal(currMeal);
                    }
                    else
                    {
                        break;
                    }
                }
                else if (currDayCal == currMealCal)
                {
                    if (meals.Any())
                    {
                        currMeal = meals.Dequeue();
                        currMealCal = GetCurrMealCal(currMeal);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    currMealCal -= currDayCal;
                }

            }
            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {input.Count} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {input.Count - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }

        }
        static int GetCurrMealCal(string meal)
        {
            int saladCal = 350;
            int soupCal = 490;
            int pastaCal = 680;
            int steakCal = 790;

            int currMealCal = 0;
            if (meal == "salad")
            {
                currMealCal = saladCal;
            }
            else if (meal == "soup")
            {
                currMealCal = soupCal;
            }
            else if (meal == "pasta")
            {
                currMealCal = pastaCal;
            }
            else if (meal == "steak")
            {
                currMealCal = steakCal;
            }
            return currMealCal;
        }
    }
}