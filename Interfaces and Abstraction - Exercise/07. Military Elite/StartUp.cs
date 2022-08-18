using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var privates = new Dictionary<int, Private>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] arr = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (arr[0] == "Private" && arr.Length == 5)
                {
                    var privS = new Private(int.Parse(arr[1]), arr[2], arr[3], decimal.Parse(arr[4]));
                    privates.Add(int.Parse(arr[1]), privS);
                    Console.WriteLine(privS);
                }
                else if (arr[0] == "LieutenantGeneral" && arr.Length >= 5)
                {
                    var lieu = new LieutenantGeneral(int.Parse(arr[1]), arr[2], arr[3], decimal.Parse(arr[4]));

                    if (arr.Length > 5)
                    {
                        for (var i = 5; i < arr.Length; i++)
                        {
                            lieu.Privates.Add(privates[int.Parse(arr[i])]);
                        }
                    }
                    Console.WriteLine(lieu);
                }
                else if (arr[0] == "Engineer" && arr.Length >= 6)
                {
                    if (arr[5] != "Airforces" && arr[5] != "Marines") continue;

                    var engineer = new Engineer(int.Parse(arr[1]), arr[2], arr[3], decimal.Parse(arr[4]), arr[5]);

                    if (arr.Length > 6)
                    {
                        for (var i = 6; i < arr.Length; i += 2)
                        {
                            var repairPartName = arr[i];
                            var repairHours = int.Parse(arr[i + 1]);

                            var repair = new Repair(repairPartName, repairHours);
                            engineer.Repairs.Add(repair);
                        }
                    }
                    Console.WriteLine(engineer);
                }
                else if (arr[0] == "Commando" && arr.Length >= 6)
                {
                    if (arr[5] != "Airforces" && arr[5] != "Marines") continue;

                    var commando = new Commando(int.Parse(arr[1]), arr[2], arr[3], decimal.Parse(arr[4]), arr[5]);

                    if (arr.Length > 6)
                    {
                        for (var i = 6; i < arr.Length; i += 2)
                        {
                            if (arr[i + 1] == "inProgress" || arr[i + 1] == "Finished")
                            {
                                var mission = new Mission(arr[i], arr[i + 1]);
                                commando.Missions.Add(mission);
                            }
                        }
                    }
                    Console.WriteLine(commando);
                }
                else if (arr[0] == "Spy" && arr.Length == 5)
                {
                    var spy = new Spy(int.Parse(arr[1]), arr[2], arr[3], int.Parse(arr[4]));
                    Console.WriteLine(spy);
                }
            }
        }
    }
}
