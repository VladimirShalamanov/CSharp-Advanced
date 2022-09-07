namespace Formula1.Models
{
    using System;
    
    using Formula1.Models.Contracts;
    using Utilities;
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horseP;
        private double engineDip;

        protected FormulaOneCar(string model, int horseP, double engineDip)
        {
            this.Model = model;
            this.Horsepower = horseP;
            this.EngineDisplacement = engineDip;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1CarModel, value));
                }

                this.model = value;
            }
        }

        public int Horsepower
        {
            get => this.horseP;
            private set
            {
                if (value < 900 && value > 1050)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }

                this.horseP = value;
            }
        }

        public double EngineDisplacement
        {
            get => this.engineDip;
            private set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }

                this.engineDip = value;
            }
        }

        public double RaceScoreCalculator(int laps) => this.EngineDisplacement / this.Horsepower * laps;
    }
}
