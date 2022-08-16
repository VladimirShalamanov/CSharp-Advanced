using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var birthdate = new List<string>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] arr = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length == 5 && arr[0] == "Citizen")
                {
                    ICitizen citizen = new Citizen(arr[1], int.Parse(arr[2]), arr[3], arr[4]);
                    birthdate.Add(citizen.Birthdate);
                }
                else if (arr.Length == 3 && arr[0] == "Pet")
                {
                    IPet pet = new Pet(arr[1], arr[2]);
                    birthdate.Add(pet.Birthdate);
                }
                else if (arr.Length == 3 && arr[0] == "Robot")
                {
                    IRobot robot = new Robot(arr[1], arr[2]);
                }
            }
            string year = Console.ReadLine();

            foreach (string y in birthdate.Where(x => x.EndsWith(year)))
            {
                Console.WriteLine(y);
            }
        }
    }
}
