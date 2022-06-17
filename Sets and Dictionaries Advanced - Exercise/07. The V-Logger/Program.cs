using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var youtube = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "Statistics")
            {
                string[] arr = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string vlogger = arr[0];
                string type = arr[1];

                if (type == "joined" && !youtube.ContainsKey(vlogger))
                {
                    youtube.Add(vlogger, new Dictionary<string, HashSet<string>>());
                    youtube[vlogger].Add("followers", new HashSet<string>());
                    youtube[vlogger].Add("following", new HashSet<string>());
                }
                else if (type == "followed")
                {
                    string member = arr[2];
                    if (vlogger != member && youtube.ContainsKey(vlogger) && youtube.ContainsKey(member))
                    {
                        youtube[vlogger]["following"].Add(member);
                        youtube[member]["followers"].Add(vlogger);
                    }
                }
            }

            int count = 1;
            Console.WriteLine($"The V-Logger has a total of {youtube.Count} vloggers in its logs.");
            foreach (var youtuber in youtube.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{count}. {youtuber.Key} : {youtuber.Value["followers"].Count} followers, {youtuber.Value["following"].Count} following");
                if (count == 1)
                {
                    foreach (string follower in youtuber.Value["followers"].OrderBy(f => f))
                        Console.WriteLine($"*  {follower}");
                }
                count++;
            }
        }
    }
}
