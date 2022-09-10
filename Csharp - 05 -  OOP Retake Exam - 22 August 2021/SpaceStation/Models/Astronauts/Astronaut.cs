namespace SpaceStation.Models.Astronauts
{
    using System;
    using Contracts;
    using Models.Bags;
    using Models.Bags.Contracts;
    using Utilities.Messages;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag { get => this.bag; private set => this.bag = value; }

        public virtual void Breath()
        {
            if (this.Oxygen - 10 < 0)
            {
                this.Oxygen = 0;
            }
            this.Oxygen -= 10;
        }
    }
}
