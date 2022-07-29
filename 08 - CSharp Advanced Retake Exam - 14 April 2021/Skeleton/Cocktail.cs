using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Exists(c => c.Name == ingredient.Name) && Ingredients.Count < Capacity && ingredient.Alcohol < MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            var coc = Ingredients.FirstOrDefault(c => c.Name == name);
            if (coc != null)
            {
                Ingredients.Remove(coc);
                return true;
            }
            return false;
        }
        public Ingredient FindIngredient(string name)
        {
            var coc = Ingredients.FirstOrDefault(c => c.Name == name);
            if (coc != null)
            {
                return coc;
            }
            return null;
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.Find(c => c.Alcohol == Ingredients.Max(a => a.Alcohol));
        }

        public int CurrentAlcoholLevel => this.Ingredients.Sum(a => a.Alcohol);

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var c in Ingredients) sb.AppendLine(c.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
