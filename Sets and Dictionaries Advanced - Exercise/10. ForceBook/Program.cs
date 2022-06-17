using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var force = new Dictionary<string, List<string>>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Lumpawaroo")
            {
                bool splitByLine = false;
                bool splitByArrow = false;
                var cmdSplitByLine = cmd.Split(" | ");
                var cmdSplitByArrow = cmd.Split(" -> ");
                if (cmdSplitByLine.Length == 2)
                    splitByLine = true;
                else if (cmdSplitByArrow.Length == 2)
                    splitByArrow = true;

                if (splitByLine)
                {
                    bool containsUser = false;
                    foreach (var team in force)
                    {
                        if (team.Value.Contains(cmdSplitByLine[1]))
                            containsUser = true;
                    }
                    if (force.ContainsKey(cmdSplitByLine[0]))
                    {
                        if (containsUser == false)
                            force[cmdSplitByLine[0]].Add(cmdSplitByLine[1]);
                    }
                    else
                    {
                        force.Add(cmdSplitByLine[0], new List<string>());
                        if (containsUser == false)
                            force[cmdSplitByLine[0]].Add(cmdSplitByLine[1]);
                    }
                }
                else if (splitByArrow)
                {
                    foreach (var team in force)
                    {
                        if (team.Value.Contains(cmdSplitByArrow[0]))
                            team.Value.Remove(cmdSplitByArrow[0]);
                    }
                    if (!force.ContainsKey(cmdSplitByArrow[1]))
                        force.Add(cmdSplitByArrow[1], new List<string>());

                    force[cmdSplitByArrow[1]].Add(cmdSplitByArrow[0]);
                    Console.WriteLine($"{cmdSplitByArrow[0]} joins the {cmdSplitByArrow[1]} side!");
                }
            }

            foreach (var kvp in force
                .Where(x => x.Value.Count >= 1)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                foreach (var item in kvp.Value.OrderBy(x => x))
                    Console.WriteLine($"! {item}");
            }
        }
    }
}
