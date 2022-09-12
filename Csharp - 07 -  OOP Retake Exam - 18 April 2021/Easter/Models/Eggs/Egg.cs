namespace Easter.Models.Eggs
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException(ExceptionMessages.InvalidEggName);
                }
                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                this.energyRequired = value;
                if (this.energyRequired < 0)
                    this.energyRequired = 0;
            }
        }

        public void GetColored() => this.EnergyRequired -= 10;

        public bool IsDone() => this.EnergyRequired == 0;
    }
}
