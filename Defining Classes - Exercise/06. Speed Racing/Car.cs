﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public string Model{ get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer{ get; set; }
        public double TravelledDistance{ get; set; }

        public void Drive(double amountOfKm)
        {
            double neededLiters = amountOfKm * FuelConsumptionPerKilometer;
            if (neededLiters <= FuelAmount)
            {
                FuelAmount -= neededLiters;
                TravelledDistance += amountOfKm;
            }
            else
                Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
