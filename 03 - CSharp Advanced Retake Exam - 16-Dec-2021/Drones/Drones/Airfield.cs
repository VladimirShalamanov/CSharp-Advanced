using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private string name;
        private int capacity;
        private double landingStrip;
        private List<Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.drones = new List<Drone>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public double LandingStrip
        {
            get { return landingStrip; }
            set { landingStrip = value; }
        }

        public IReadOnlyCollection<Drone> Drones
        {
            get { return drones; }
        }

        public int Count
            => this.Drones.Count;

        public string AddDrone(Drone drone)
        {
            var result = new StringBuilder();

            if (capacity - Count <= 0)
            {
                result.AppendLine("Airfield is full.");
            }
            else if (string.IsNullOrEmpty(drone.Name) ||
                string.IsNullOrEmpty(drone.Brand) ||
                drone.Range < 5 ||
                drone.Range > 15)
            {
                result.AppendLine("Invalid drone.");
            }
            else
            {
                this.drones.Add(drone);
                result.AppendLine($"Successfully added {drone.Name} to the airfield.");
            }

            return result.ToString().TrimEnd();
        }

        public bool RemoveDrone(string name)
        {
            var result = false;
            var droneToRemove = this.drones.FirstOrDefault(d => d.Name == name);
            if (droneToRemove != null)
            {
                this.drones.Remove(droneToRemove);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public int RemoveDroneByBrand(string brand)
        {
            var result = 0;
            var dronesToRemove = this.drones.Where(d => d.Brand == brand).ToList();
            if (dronesToRemove.Count() > 0)
            {
                result = dronesToRemove.Count();
                foreach (var drone in dronesToRemove)
                {
                    this.drones.Remove(drone);
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public Drone FlyDrone(string name)
        {
            var currentDrone = this.drones.FirstOrDefault(d => d.Name == name);
            if (currentDrone != null)
            {
                currentDrone.Available = false;
                return currentDrone;
            }
            else
            {
                return null;
            }
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            var flyingDrones = this.drones.Where(d => d.Range >= range);
            return flyingDrones.ToList();
        }

        public string Report()
        {
            var result = new StringBuilder();
            result.AppendLine($"Drones available at {this.Name}:");

            var dronesNotInFlight = this.drones.Where(d => d.Available == true);
            foreach (var drone in dronesNotInFlight)
            {
                result.AppendLine(drone.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}