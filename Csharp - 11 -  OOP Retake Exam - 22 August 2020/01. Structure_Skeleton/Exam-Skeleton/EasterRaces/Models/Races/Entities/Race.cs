namespace EasterRaces.Models.Races.Entities
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using EasterRaces.Models.Drivers.Contracts;
    using Utilities.Messages;
    using System.Linq;
    using System.Collections.ObjectModel;

    public class Race : IRace
    {
        private string name;
        private int laps;
        private ICollection<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
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

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers 
            =>  (IReadOnlyCollection<IDriver>)this.drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }
            if (!driver.CanParticipate)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (this.drivers.Any(x => x == driver))
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }
            this.drivers.Add(driver);
        }
    }
}
