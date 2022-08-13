using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] arr = cmd.Split(';', StringSplitOptions.RemoveEmptyEntries);
                    string cmd1 = arr[0];
                    string teamN = arr[1];

                    if (cmd1 == "Team")
                    {
                        Team team = new Team(teamN);
                        teams.Add(team);
                    }
                    else
                    {
                        Team team = teams
                                .FirstOrDefault(t => t.Name == teamN);

                        if (team == null)
                        {
                            throw new InvalidOperationException($"Team {teamN} does not exist.");
                        }

                        if (cmd1 == "Add")
                        {
                            string playerN = arr[2];

                            Player player = new Player(playerN, int.Parse(arr[3]), int.Parse(arr[4]), int.Parse(arr[5]), int.Parse(arr[6]), int.Parse(arr[7]));

                            team.Add(player);
                        }
                        else if (cmd1 == "Remove")
                        {
                            string playerN = arr[2];

                            team.Remove(playerN);
                        }
                        else if (cmd1 == "Rating")
                        {
                            Console.WriteLine($"{team.Name} - {team.Rating}");
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("A name should not be empty.");
                }
            }
        }
    }
}
