﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public string Name { get; set; }

        private int badges;
        public int Badges
        {
            get => badges;
            set => this.badges = 0;
        }
        public List<Pokemon> Pokemons = new List<Pokemon>();

        public Trainer(string trainerName)
        {
            this.Name = trainerName;
        }
        public void AddBadge()
        {
            badges += 1;
        }
        public void ReduceHealth()
        {
            foreach (var pokemon in Pokemons)
            {
                pokemon.Health -= 10;
            }
        }
        public void ClearDeadPokemons()
        {
            Pokemons.RemoveAll(pokemons => pokemons.Health <= 0);
        }
    }
}
