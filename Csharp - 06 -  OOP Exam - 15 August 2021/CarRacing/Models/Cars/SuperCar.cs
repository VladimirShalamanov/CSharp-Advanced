namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double FuelAvailableCar = 80;
        private const double FuelConsumptionPerRaceCar = 10;

        public SuperCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, FuelAvailableCar, FuelConsumptionPerRaceCar)
        {
        }
    }
}
