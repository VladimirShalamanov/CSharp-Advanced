using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_by_Age
    {
        class Program
        {
            static void Main(string[] args)
            {
                Func<(string name, int age), int, bool> youngerFunc = (person, age) => person.age < age;
                Func<(string name, int age), int, bool> olderFunc = (person, age) => person.age >= age;

                int n = int.Parse(Console.ReadLine());
                List<(string name, int age)> people = new List<(string name, int age)>();

                for (int i = 0; i < n; i++)
                {
                    string[] cmdArr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                    string name = cmdArr[0];
                    int age = int.Parse(cmdArr[1]);

                    people.Add((name, age));
                }

                string condition = Console.ReadLine();
                int ageFilter = int.Parse(Console.ReadLine());
                string[] printFilter = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (condition)
                {
                    case "younger":
                        people = people.Where(p => youngerFunc(p, ageFilter)).ToList();
                        break;
                    case "older":
                        people = people.Where(p => olderFunc(p, ageFilter)).ToList();
                        break;
                    default:
                        break;
                }

                foreach (var person in people)
                {
                    List<string> output = new List<string>();
                    if (printFilter.Contains("name"))
                    {
                        output.Add(person.name);
                    }

                    if (printFilter.Contains("age"))
                    {
                        output.Add(person.age.ToString());
                    }

                    Console.WriteLine(string.Join(" - ", output));
                }
            }
        }
    }
