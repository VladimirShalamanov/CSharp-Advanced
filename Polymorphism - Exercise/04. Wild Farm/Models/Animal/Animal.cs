namespace P04.WildFarm.Models.Animal
{
    using P04.WildFarm.Interfaces;
    using P04.WildFarm.Models.Food;
    using System;

    public abstract class Animal : IAnimal
    {
        private string name;
        private double weight;

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.weight = value;
            }
        }

        public int FoodEaten { get; protected set; }

        public abstract void Feed(Food food);

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
}
