using System;
using System.Collections.Generic;
using System.Text;

namespace P04PizzaCalories
{
    public class Topping
    {
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

        private string type;
        private double grams;

        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }

        public string Type
        {
            get { return this.type; }
            private set
            {
                string type = value.ToLower();
                if (!string.IsNullOrEmpty(type) && type == "meat" || type == "veggies" || type == "cheese" || type == "sauce")
                {
                    this.type = type;
                    return;
                }
                var valueName = value[0].ToString().ToUpper() + value.Substring(1);
                throw new Exception($"Cannot place {valueName} on top of your pizza.");
            }
        }

        public double Grams
        {
            get { return this.grams; }
            private set
            {
                if (value >= 1 && value <= 50)
                {
                    this.grams = value;
                    return;
                }
                var valueName = this.Type[0].ToString().ToUpper() + this.Type.Substring(1);
                throw new Exception($"{valueName} weight should be in the range [1..50].");
            }
        }

        public double BakingT()
        {
            double type = 0;
            if (this.Type == "meat") type = Meat;
            else if (this.Type == "veggies") type = Veggies;
            else if (this.Type == "cheese") type = Cheese;
            else if (this.Type == "sauce") type = Sauce;

            return (2 * this.Grams) * type;
        }
    }
}
