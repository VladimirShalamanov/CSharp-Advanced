using System;
using System.Collections.Generic;
using System.Text;

namespace P02.VehiclesExtension.Validator
{
    public class Validator
    {
        public static void CheckPositiveNumber(double value)
        {
            if (value < 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }
    }
}
