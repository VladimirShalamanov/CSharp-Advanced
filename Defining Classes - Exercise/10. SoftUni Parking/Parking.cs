using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public List<Car> Cars { get { return cars; } set { cars = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }

        public int Count { get { return Cars.Count; } }

        public Parking(int capacity)
        {
            Cars = new List<Car>();
            Capacity = capacity;
        }

        public string AddCar(Car addedCar)
        {
            bool canAddCar = true;
            foreach (Car car in cars)
            {
                if (car.RegistrationNumber == addedCar.RegistrationNumber)
                {
                    canAddCar = false;
                    return "Car with that registration number, already exists!";
                }
            }
            if (cars.Count + 1 > capacity)
            {
                canAddCar = false;
                return "Parking is full!";
            }
            if (canAddCar)
            {
                Cars.Add(addedCar);
                return $"Successfully added new car {addedCar.Make} {addedCar.RegistrationNumber}";
            }

            return "";
        }

        public string RemoveCar(string registrationNumber)
        {
            bool isAvaliable = false;
            foreach (Car car in cars)
            {
                if (car.RegistrationNumber == registrationNumber)
                {
                    isAvaliable = true;
                }
            }
            if (isAvaliable)
            {
                Car carToRemove = Cars.First(c => c.RegistrationNumber == registrationNumber);
                Cars.Remove(carToRemove);
                return $"Successfully removed {registrationNumber}";
            }
            else
                    return "Car with that registration number, already exists!";
        }

        public Car GetCar (string registrationNumber)
        {
            return Cars.First(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (string RegistrationNumber in RegistrationNumbers)
            {
                RemoveCar(RegistrationNumber);
            }
        }
    }
}
