using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Party!")
            {
                Predicate<string> predicate = GetPredicate(cmd);
                if (cmd.StartsWith("Double"))
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (predicate(people[i]))
                        {
                            people.Insert(i + 1, people[i]);
                            i++;
                        }
                    }
                }
                else if (cmd.StartsWith("Remove"))
                    people.RemoveAll(predicate);
            }

            if (people.Count == 0)
                Console.WriteLine("Nobody is going to the party!");
            else
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
        }

        private static Predicate<string> GetPredicate(string cmd)
        {
            Predicate<string> predicate = null;
            string startEnd = cmd.Split()[1];
            string word = cmd.Split()[2];
            if (startEnd == "StartsWith")
            {
                predicate = name => name.StartsWith(word);
            }
            else if (startEnd == "EndsWith")
            {
                predicate = name => name.EndsWith(word);

            }
            else if (startEnd == "Length")
            {
                predicate = name => name.Length == int.Parse(word);

            }
            return predicate;
        }
    }
}
