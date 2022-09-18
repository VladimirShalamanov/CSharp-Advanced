namespace EasterRaces.Models.Cars.Entities
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int min;
        private int max;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHp, int maxHp)
        {
            this.minHp = minHp;
            this.maxHp = maxHp;
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }
        public int minHp { get => this.min; protected set => this.min = value; }
        public int maxHp { get => this.max; protected set => this.max = value; }
        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 4)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, 4));
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value < minHp || value > maxHp)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get => this.cubicCentimeters; private set => this.cubicCentimeters= value; }

        public double CalculateRacePoints(int laps) => this.CubicCentimeters / this.HorsePower  * laps;
    }
}
