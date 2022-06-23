using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var listTrainers = new List<Trainer>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Tournament")
            {
                string[] arr = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string trainerName = arr[0];
                string pokemonName = arr[1];
                string pokemonElement = arr[2];
                int pokemonHealth = int.Parse(arr[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                var currTreiner = listTrainers.FirstOrDefault(t => t.Name == trainerName);

                if (currTreiner != null)
                {
                    currTreiner.Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    listTrainers.Add(trainer);
                } 
            }

            string element;
            while ((element = Console.ReadLine()) != "End")
            {
                foreach (var trainer in listTrainers)
                {
                    if (trainer.Pokemons.Exists(pokemon => pokemon.Element == element))
                        trainer.AddBadge();
                    else
                        trainer.ReduceHealth();
                    trainer.ClearDeadPokemons();
                }
            }

            foreach (var trainer in listTrainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
