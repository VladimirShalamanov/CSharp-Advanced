using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    internal class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;


        public Car()
        {
            this.make = "VW";
            this.model = "Golf";
            this.year = 2025;
            this.fuelQuantity = 200;
            this.fuelConsumption = 10;
        }

        public Car (string make, string model, int year) : this()
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.fuelQuantity = 200;
            this.fuelConsumption = 10;
        }
        public Car (string make, string model, int year, double fuelQuantity, double fuelConsumption): this (make, model, year)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
            this.Engine = engine;
            this.Tires = tires;
        }

        internal void Drive(double distance)
        {
            if (distance * fuelConsumption <= this.FuelQuantity)
                this.FuelQuantity -= distance * fuelConsumption;
            else
                Console.WriteLine("Not enough fuel to perform this trip!");
        }

        internal string WhoAmI()
        {
            string info = $"{this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L";
            return info;
        }

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }
    }
}
