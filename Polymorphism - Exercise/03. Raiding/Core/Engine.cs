namespace P03.Raiding.Core
{
    using P03.Raiding.Factory;
    using P03.Raiding.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private ICollection<BaseHero> heroes;

        public Engine()
        {
            heroes = new List<BaseHero>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;

            while (count != n)
            {
                string name = Console.ReadLine();
                string typeHero = Console.ReadLine();

                try
                {
                    BaseHero hero = FactoryHero.CreateHero(typeHero, name);
                    heroes.Add(hero);
                    count++;
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            double bossPower = double.Parse(Console.ReadLine());

            foreach (var h in heroes)
            {
                Console.WriteLine(h.CastAbility());
            }
            int sum = heroes.Sum(h => h.Power);

            if (sum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
