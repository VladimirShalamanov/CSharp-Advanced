namespace EasterRaces.Models.Drivers.Entities
{
    using System;
    using Contracts;
    using EasterRaces.Models.Cars.Contracts;
    using Utilities.Messages;

    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this.name = value;
            }
        }

        public ICar Car => this.car;

        public int NumberOfWins => this.numberOfWins;

        public bool CanParticipate => this.Car != null;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
            this.car = car;
        }

        public void WinRace() => this.numberOfWins++;
    }
}
