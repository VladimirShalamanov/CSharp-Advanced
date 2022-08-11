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
                string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string f = arr[0];
                string l = arr[1];
                int a = int.Parse(arr[2]);
                var person = new Person(f, l, a);
                peoples.Add(person);
            }

            peoples.OrderBy(p => p.FirstName)
           .ThenBy(p => p.Age)
           .ToList()
           .ForEach(p => Console.WriteLine(p.ToString()));

        }
    }
}
