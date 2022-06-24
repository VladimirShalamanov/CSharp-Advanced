using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<List<double>> listTiresYears = new List<List<double>>();
            List<List<double>> listTiresPressures = new List<List<double>>();
            List<int> listHorsePowers = new List<int>();
            List<double> listCubicCapacity = new List<double>();
            List<Car> listCars = new List<Car>();

            Tires tires = new Tires();
            Engine engine = new Engine();

            string cmdTires;
            while ((cmdTires = Console.ReadLine()) != "No more tires")
            {
                string[] splitted = cmdTires.Split();
                List<double> listYears = tires.GetYearInfo(splitted);
                List<double> listPressures = tires.GetPressureInfo(splitted);

                listTiresYears.Add(listYears);
                listTiresPressures.Add(listPressures);
            }

            string cmdEngines;
            while ((cmdEngines = Console.ReadLine()) != "Engines done")
            {
                string[] splitted = cmdEngines.Split();
                listHorsePowers.Add(int.Parse(splitted[0]));
                listCubicCapacity.Add(double.Parse(splitted[1]));
            }

            string cmdCars;
            while ((cmdCars = Console.ReadLine()) != "Show special")
            {
                string[] splitted = cmdCars.Split();
                string make = splitted[0];
                string model = splitted[1];
                int year = int.Parse(splitted[2]);
                double fuelQuantity = double.Parse(splitted[3]);
                double fuelConsumption = double.Parse(splitted[4]);
                int engineIndex = int.Parse(splitted[5]);
                int tiresIndex = int.Parse(splitted[6]);

                int horsePower = listHorsePowers[engineIndex];
                double pressure = listTiresPressures[tiresIndex].Sum();

                Car car = new Car(make, model, year, horsePower, fuelQuantity, fuelConsumption,
                    engineIndex, tiresIndex, pressure);
                listCars.Add(car);
            }

            foreach (var car in listCars)
            {
                if (car.Year >= 2017 && car.HorsePower > 330
                    && car.TotalPressure > 9 && car.TotalPressure < 10)
                {
                    car.FuelQuantity -= (car.FuelConsumption / 100) * 20;

                    Console.WriteLine($"Make: {car.Make}");

                    Console.WriteLine($"Model: {car.Model}");

                    Console.WriteLine($"Year: {car.Year}");

                    Console.WriteLine($"HorsePowers: {car.HorsePower}");

                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}
