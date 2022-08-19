namespace P01.Vehicles.Core
{
    using P01.Vehicles.Models.Interfaces;
    using System;

    public class Engine : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;

        public Engine(Vehicle car, Vehicle truck)
        {
            this.car = car;
            this.truck = truck;
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
                        Console.WriteLine(this.car.Drive(param));
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(this.truck.Drive(param));
                    }
                }
                else if (type == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                       this.car.Refuel(param);
                    }
                    else if (vehicle == "Truck")
                    {
                        this.truck.Refuel(param);
                    }
                }
            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
        }
    }
}
