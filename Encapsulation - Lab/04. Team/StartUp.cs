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
            Team team = new Team("SoftUni");

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string f = arr[0];
                string l = arr[1];
                int a = int.Parse(arr[2]);
                decimal s = decimal.Parse(arr[3]);
                var person = new Person(f, l, a, s);
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team have {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team have {team.ReserveTeam.Count} players.");
        }
    }
}
