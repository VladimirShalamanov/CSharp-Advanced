using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] name = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!students.ContainsKey(name[0]))
                    students[name[0]] = new List<decimal>();
                students[name[0]].Add(decimal.Parse(name[1]));
            }

            foreach (var kvp in students)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(' ', kvp.Value.Select(x => $"{x:f2}"))} " +
                    $"(avg: {kvp.Value.Average():f2})");
            }
        }
    }
}