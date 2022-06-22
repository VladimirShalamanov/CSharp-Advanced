using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var enginesList = new List<Engine>();
            var carsList = new List<Car>();

            int engines = int.Parse(Console.ReadLine());

            for (int i = 0; i < engines; i++)
            {
                string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (arr.Length == 2)
                {
                    string model = arr[0];
                    int power = int.Parse(arr[1]);
                    Engine newEngine = new Engine(model, power);
                    enginesList.Add(newEngine);
                }
                else if (arr.Length == 3)
                {
                    string model = arr[0];
                    int power = int.Parse(arr[1]);
                    string third = arr[2];
                    if (int.TryParse(third, out int displacement))
                    {
                        Engine newEngine = new Engine(model, power, displacement);
                        enginesList.Add(newEngine);
                    }
                    else
                    {
                        string efficiency = arr[2];
                        Engine newEngine = new Engine(model, power, efficiency);
                        enginesList.Add(newEngine);
                    }
                }
                else if (arr.Length == 4)
                {
                    string model = arr[0];
                    int power = int.Parse(arr[1]);
                    int displacement = int.Parse(arr[2]);
                    string efficiency = arr[3];
                    Engine newEngine = new Engine(model, power, displacement, efficiency);
                    enginesList.Add(newEngine);
                }
            }

            int cars = int.Parse(Console.ReadLine());
            for (int i = 0; i < cars; i++)
            {
                string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (arr.Length == 2)
                {
                    string carModel = arr[0];
                    string engineModel = arr[1];
                    if (enginesList.Exists(e => e.Model == engineModel))
                    {
                        Engine findEngine = enginesList.Where(e => e.Model == engineModel).First();
                        Car newCar = new Car(carModel, findEngine);
                        carsList.Add(newCar);
                    }
                }
                else if (arr.Length == 3)
                {
                    string carModel = arr[0];
                    string engineModel = arr[1];
                    string third = arr[2];
                    if (enginesList.Exists(e => e.Model == engineModel))
                    {
                        Engine findEngine = enginesList.Where(e => e.Model == engineModel).First();
                        if (int.TryParse(third, out int weight))
                        {
                            Car newCar = new Car(carModel, findEngine, weight);
                            carsList.Add(newCar);
                        }
                        else
                        {
                            string color = arr[2];
                            Car newCar = new Car(carModel, findEngine, color);
                            carsList.Add(newCar);
                        }
                    }
                }
                else if (arr.Length == 4)
                {
                    string carModel = arr[0];
                    string engineModel = arr[1];
                    if (enginesList.Exists(e => e.Model == engineModel))
                    {
                        Engine findEngine = enginesList.Where(e => e.Model == engineModel).First();
                        int weight = int.Parse(arr[2]);
                        string color = arr[3];
                        Car newCar = new Car(carModel, findEngine, weight, color);
                        carsList.Add(newCar);
                    }
                }
            }

            foreach (var car in carsList)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
