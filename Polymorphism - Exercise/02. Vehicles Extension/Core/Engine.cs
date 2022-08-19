namespace P02.VehiclesExtension
{
    using P02.VehiclesExtension.Core;
    using P02.VehiclesExtension.Models.Interfaces;
    using System;

    public class Engine : IEngine
    {
        private readonly Car car;
        private readonly Truck truck;
        private readonly Bus bus;

        public Engine(Car car, Truck truck, Bus bus)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }

        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();
                string type = arr[0];
                string vehicle = arr[1];
                double param = double.Parse(arr[2]);

                if (type == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        car.Drive(param);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Drive(param);
                    }
                    else if (vehicle == "Bus")
                    {
                        bus.Drive(param);
                    }
                }
                else if (type == "DriveEmpty")
                {
                    if (vehicle == "Bus")
                    {
                        bus.DriveEmpty(param);
                    }
                }
                else if (type == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(param);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(param);
                    }
                    else if (vehicle == "Bus")
                    {
                        bus.Refuel(param);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
