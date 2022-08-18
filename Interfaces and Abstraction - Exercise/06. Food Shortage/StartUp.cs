using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var namesC = new List<Citizen>();
            var namesR = new List<Rebel>();
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length == 4 && !namesC.Any(x => x.Name == arr[0])
                                    && !namesR.Any(x => x.Name == arr[0]))
                {
                    ICitizen citizen = new Citizen(arr[0], int.Parse(arr[1]), arr[2], arr[3]);
                    namesC.Add(new Citizen(arr[0], int.Parse(arr[1]), arr[2], arr[3]));
                }
                else if (arr.Length == 3 && !namesC.Any(x => x.Name == arr[0])
                                         && !namesR.Any(x => x.Name == arr[0]))
                {
                    IRebel rebel = new Rebel(arr[0], int.Parse(arr[1]), arr[2]);
                    namesR.Add(new Rebel(arr[0], int.Parse(arr[1]), arr[2]));
                }
            }
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                if (namesC.Any(x => x.Name == cmd))
                {
                    Citizen cit = namesC.First(x => x.Name == cmd);
                    cit.BuyFood();
                }
                else if (namesR.Any(x => x.Name == cmd))
                {
                    Rebel reb = namesR.First(x => x.Name == cmd);
                    reb.BuyFood();
                }
            }

            Console.WriteLine(namesC.Sum(x => x.Food) + namesR.Sum(x => x.Food));
        }
    }
}
