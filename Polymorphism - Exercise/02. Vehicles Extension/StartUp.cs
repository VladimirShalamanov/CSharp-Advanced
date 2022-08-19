namespace P02.VehiclesExtension
{
    using System;
    using P02.VehiclesExtension.Core;
    using P02.VehiclesExtension.Models.Interfaces;
    using P02.VehiclesExtension.Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carD = Console.ReadLine().Split();
            string[] truckD = Console.ReadLine().Split();
            string[] busD = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carD[1]), double.Parse(carD[2]), double.Parse(carD[3]));
            Truck truck = new Truck(double.Parse(truckD[1]), double.Parse(truckD[2]), double.Parse(truckD[3]));
            Bus bus = new Bus(double.Parse(busD[1]), double.Parse(busD[2]), double.Parse(busD[3]));

            IEngine engine = new Engine(car, truck, bus);
            engine.Start();
        }
    }
}
