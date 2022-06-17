using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listOfContests = new Dictionary<string, string>();
            var contest = new SortedDictionary<string, Dictionary<string, int>>();

            string cmd1;
            while ((cmd1 = Console.ReadLine()) != "end of contests")
            {
                string[] arr = cmd1.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string currContest = arr[0];
                string password = arr[1];

                listOfContests.Add(currContest, password);
            }

            string cmd2;
            while ((cmd2 = Console.ReadLine()) != "end of submissions")
            {
                string[] arr = cmd2.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string currContest = arr[0];
                string password = arr[1];
                string username = arr[2];
                int points = int.Parse(arr[3]);

                if (listOfContests.ContainsKey(currContest) && listOfContests.ContainsValue(password))
                {
                    if (!contest.ContainsKey(username))
                    {
                        contest.Add(username, new Dictionary<string, int>());
                        contest[username].Add(currContest, points);
                    }
                    if (contest[username].ContainsKey(currContest))
                    {
                        if (contest[username][currContest] < points)
                            contest[username][currContest] = points;
                    }
                    else
                        contest[username].Add(currContest, points);
                }
            }

            var totalPoints = new Dictionary<string, int>();
            foreach (var kvp in contest)
                totalPoints[kvp.Key] = kvp.Value.Values.Sum();

            string bestName = totalPoints.Keys.Max();
            int bestPoints = totalPoints.Values.Max();

            foreach (var kvp in totalPoints)
            {
                if (kvp.Value == bestPoints)
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");
            }
            Console.WriteLine("Ranking:");
            foreach (var name in contest)
            {
                Dictionary<string, int> dict = name.Value;
                dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine($"{name.Key}");
                foreach (var kvp in dict)
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");

            }
        }
    }
}
