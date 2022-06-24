using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        public int HorsePower { get; set; }
        public double CubicCapasity { get; set; }

        public Engine(int horsePower, double cubicCapasity)
        {
            this.HorsePower = horsePower;
            this.CubicCapasity = cubicCapasity;
        }

        public static void Run()
        {
            Console.WriteLine("I am an engine. I am running.");
        }
    }
}
