using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals { get; private set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Animals = new List<Animal>();
        }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (this.Animals.Count + 1 > this.Capacity)
            {
                return "The zoo is full.";
            }
            this.Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = 0;
            if (this.Animals.Exists(a => a.Species == species))
            {
                count = this.Animals.RemoveAll(a => a.Species == species);
            }
            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalsByDiet = this.Animals.Where(a => a.Diet == diet).ToList();
            return animalsByDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            Animal animalsByWeight =
                this.Animals.FirstOrDefault(a => a.Weight == weight);
            if (animalsByWeight == null)
            {
                return null;
            }
            return animalsByWeight;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = this.Animals.
                Where(l => l.Length >= minimumLength && l.Length <= maximumLength).Count();

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
