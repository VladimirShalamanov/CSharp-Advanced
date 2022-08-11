using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var peoples = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                Person person = null;
                try
                {
                    string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string f = arr[0];
                    string l = arr[1];
                    int a = int.Parse(arr[2]);
                    decimal s = decimal.Parse(arr[3]);
                    person = new Person(f, l, a, s);
                    peoples.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            decimal parcentage = decimal.Parse(Console.ReadLine());
            peoples.ForEach(p => p.IncreaseSalary(parcentage));
            peoples.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
