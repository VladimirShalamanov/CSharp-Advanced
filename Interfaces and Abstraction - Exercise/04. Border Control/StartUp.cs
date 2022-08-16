using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var ids = new List<string>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] arr = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length == 3)
                {
                    ICitizens citizen = new Citizens(arr[0], int.Parse(arr[1]), arr[2]);
                    ids.Add(citizen.Id);
                }
                else if (arr.Length == 2)
                {
                    IRobots robot = new Robots(arr[0], arr[1]);
                    ids.Add(robot.Id);
                }
            }
            string lastDigits = Console.ReadLine();

            foreach (string id in ids.Where(x => x.EndsWith(lastDigits)))
            {
                Console.WriteLine(id);
            }
        }
    }
}
