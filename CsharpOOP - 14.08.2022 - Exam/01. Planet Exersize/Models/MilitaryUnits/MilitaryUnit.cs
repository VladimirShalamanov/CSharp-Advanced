namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;

        protected MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = 1;
        }

        public double Cost { get => this.cost; private set => this.cost = value; }

        public int EnduranceLevel { get => this.enduranceLevel; private set => this.enduranceLevel = value; }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;
            if (this.EnduranceLevel > 20)
            {
                this.EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
