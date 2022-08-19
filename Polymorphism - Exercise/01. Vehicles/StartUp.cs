namespace P01.Vehicles
{
    using System;
    using P01.Vehicles.Core;
    using Factories;
    using Factories.Interfaces;
    using P01.Vehicles.Models.Interfaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carD = Console.ReadLine().Split();
            string[] truckD = Console.ReadLine().Split();

            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicle car = vehicleFactory.CreateVehicle(carD[0], double.Parse(carD[1]), double.Parse(carD[2]));
            Vehicle truck = vehicleFactory.CreateVehicle(truckD[0], double.Parse(truckD[1]), double.Parse(truckD[2]));

            IEngine engine = new Engine(car, truck);
            engine.Start();
        }
    }
}
