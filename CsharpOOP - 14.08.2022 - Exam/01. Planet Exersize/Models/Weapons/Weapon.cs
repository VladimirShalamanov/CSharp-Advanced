namespace PlanetWars.Models.Weapons
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;

        protected Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }

        public double Price { get => this.price; private set => this.price = value; }

        public int DestructionLevel
        {
            get => this.destructionLevel;
            protected set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                if (value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                this.destructionLevel = value;
            }
        }
    }
}
