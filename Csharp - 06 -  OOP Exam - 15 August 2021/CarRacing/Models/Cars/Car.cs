namespace CarRacing.Models.Cars
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        protected Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = vin;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get => this.make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }
                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }
                this.model = value;
            }
        }


        public string VIN
        {
            get => this.vin;
            private set
            {
                if (value.Length == 17)
                    this.vin = value;
                else
                throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }
                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get => this.fuelAvailable;
            protected set
            {
                if (value < 0)
                {
                    this.fuelAvailable = 0;
                }
                this.fuelAvailable = value;
            }
        }

        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumptionPerRace;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }
                this.fuelConsumptionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
        }
    }
}
