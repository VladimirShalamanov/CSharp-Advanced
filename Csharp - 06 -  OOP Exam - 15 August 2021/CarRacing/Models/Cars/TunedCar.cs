namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double FuelAvailableCar = 65;
        private const double FuelConsumptionPerRaceCar = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, FuelAvailableCar, FuelConsumptionPerRaceCar)
        {
        }

        public override void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
            this.HorsePower -= (int)Math.Round(this.HorsePower * 0.03, MidpointRounding.AwayFromZero);
        }
    }
}
