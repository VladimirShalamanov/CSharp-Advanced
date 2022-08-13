using System;
using System.Collections.Generic;
using System.Text;

namespace P03ShoppingSpree
{
    public class Product
    {
        private string name;
        private int cost;

        public Product(string name, int cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public int Cost
        {
            get { return this.cost; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                this.cost = value;
            }
        }
    }
}
