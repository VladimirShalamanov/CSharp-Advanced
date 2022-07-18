using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ingredientsList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> freshnessList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var dishesh = new Dictionary<string, int>()
            {
                { "Chocolate cake", 0 },
                { "Dipping sauce", 0 },
                { "Green salad", 0 },
                { "Lobster", 0 }
            };
            var ingredientsQueue = new Queue<int>(ingredientsList);
            var freshStack = new Stack<int>(freshnessList);

            while (ingredientsQueue.Any() && freshStack.Any())
            {
                int ingredient = ingredientsQueue.Dequeue();
                if (ingredient == 0) continue;
                int fresh = freshStack.Pop();
                int result = ingredient * fresh;

                if (result == 150) dishesh["Dipping sauce"]++;
                else if (result == 250) dishesh["Green salad"]++;
                else if (result == 300) dishesh["Chocolate cake"]++;
                else if (result == 400) dishesh["Lobster"]++;
                else { ingredient += 5; ingredientsQueue.Enqueue(ingredient); }

            }

            if (dishesh.Values.Count(d => d >= 1) >= 4) Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            else Console.WriteLine("You were voted off. Better luck next year.");

            if (ingredientsQueue.Any()) Console.WriteLine($"Ingredients left: {ingredientsQueue.Sum()}");
            foreach (var d in dishesh.Where(v => v.Value > 0)) Console.WriteLine($" # {d.Key} --> {d.Value}");
        }
    }
}
