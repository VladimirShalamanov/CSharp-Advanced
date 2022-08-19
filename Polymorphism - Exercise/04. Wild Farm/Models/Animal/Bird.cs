namespace P04.WildFarm.Models.Animal
{
    using P04.WildFarm.Interfaces;
    using System;

    public abstract class Bird : Animal, IBird
    {
        private double wingSize;

        protected Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize
        {
            get => this.wingSize;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException();
                }
                this.wingSize = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.WingSize}, {base.Weight}, {base.FoodEaten}]";
        }
    }
}
