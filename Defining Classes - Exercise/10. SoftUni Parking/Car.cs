using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public string Make { get{return make;} set{make = value;} }
        public string Model { get { return model; } set { model = value; } }
        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
        public string RegistrationNumber { get { return registrationNumber; } set { registrationNumber = value; } }

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Make: {this.Make}").Append(Environment.NewLine);
            sb.Append($"Model: {this.Model}").Append(Environment.NewLine);
            sb.Append($"HorsePower: {this.HorsePower}").Append(Environment.NewLine);
            sb.Append($"RegistrationNumber: {this.RegistrationNumber}");
            return sb.ToString().Trim();
        }
    }
}
