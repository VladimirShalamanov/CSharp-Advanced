namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Decorations.Contracts;
    using Models.Fish.Contracts;
    using Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decoration;
        private List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decoration = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get => this.capacity; private set => this.capacity = value; }

        public ICollection<IDecoration> Decorations => this.decoration;

        public ICollection<IFish> Fish => this.fish;

        public int Comfort => this.decoration.Sum(x => x.Comfort);

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public bool RemoveFish(IFish fish) => this.fish.Remove(fish);

        public void AddDecoration(IDecoration decoration) => this.decoration.Add(decoration);

        public void Feed()
        {
            foreach (IFish f in this.fish)
            {
                f.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: " + (this.Fish.Any() ? string.Join(", ", this.Fish.Select(x => x.Name)) : "none"));
            sb.AppendLine($"Decorations: {this.Decorations.Count()}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
