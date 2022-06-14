using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parking = new HashSet<string>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] parts = cmd.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (parts[0] == "IN")
                    parking.Add(parts[1]);
                else
                    parking.Remove(parts[1]);
            }
            if (parking.Count > 0)
            {
                foreach (var car in parking)
                    Console.WriteLine(car);
                return;
            }
            Console.WriteLine("Parking Lot is Empty");
        }
    }
}
