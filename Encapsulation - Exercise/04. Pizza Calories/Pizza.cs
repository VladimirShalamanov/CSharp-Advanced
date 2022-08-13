using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;

        public Pizza(string name) : this()
        {
            this.Name = name;
        }
        public Pizza()
        {
            this.Toppings = new List<Topping>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }

        public List<Topping> Toppings { get; }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count >= 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            this.Toppings.Add(topping);
        }

        public double TotalCalories()
        {
            double doughCalories = this.dough.BakingD();
            double toppingsCalories = this.Toppings.Sum(t => t.BakingT());
            return doughCalories + toppingsCalories;
        }
    }
}
