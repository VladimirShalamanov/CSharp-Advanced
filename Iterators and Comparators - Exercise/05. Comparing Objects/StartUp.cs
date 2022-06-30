using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                var arr = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personName = arr[0];
                int personAge = int.Parse(arr[1]);
                string personTown = arr[2];
                persons.Add(new Person(personName, personAge, personTown));
            }
            int index = int.Parse(Console.ReadLine()) - 1;
            int equal = 0;
            int notEqual = 0;
            foreach (var person in persons)
            {
                if (persons[index].CompareTo(person) == 0)
                {
                    equal++;
                }
                else
                {
                    notEqual++;
                }
            }
            if (equal <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {notEqual} {persons.Count}");
            }
        }
    }
}
