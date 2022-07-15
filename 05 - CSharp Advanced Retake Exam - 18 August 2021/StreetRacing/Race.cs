using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public int Count
        {
            get => this.Participants.Count;
        }

        public void Add(Car car)
        {
            if (!this.Participants.Exists(c => c.LicensePlate == car.LicensePlate) && 
                this.Participants.Count + 1 <= Capacity && 
                car.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            bool isRemoved = true;
            var removeCar = this.Participants.FirstOrDefault(l => l.LicensePlate == licensePlate);
            if (removeCar == null)
            {
                return isRemoved = false;
            }
            this.Participants.Remove(removeCar);
            return isRemoved;
        }

        public Car FindParticipant(string licensePlate)
        {
            var car = this.Participants.FirstOrDefault(l => l.LicensePlate == licensePlate);
            if (car == null)
            {
                return null;
            }
            return car;
        }

        public Car GetMostPowerfulCar()
        {
            var car = this.Participants.FirstOrDefault(c => c.HorsePower == this.Participants.Max(h => h.HorsePower));
            if (car == null)
            {
                return null;
            }
            return car;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants) sb.AppendLine($"{car}");
            return sb.ToString().TrimEnd();
        }
    }
}
