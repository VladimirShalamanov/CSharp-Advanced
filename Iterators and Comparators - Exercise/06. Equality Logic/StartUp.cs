using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var sortedSet = new HashSet<Person>();
            var hashSet = new HashSet<Person>();
            for (int i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine().Split();
                var person = new Person(tokens[0], int.Parse(tokens[1]));
                sortedSet.Add(person);
                hashSet.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
