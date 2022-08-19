namespace P01.Vehicles.Factories.Interfaces
{
    using P01.Vehicles.Models.Interfaces;

    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption);
    }
}
