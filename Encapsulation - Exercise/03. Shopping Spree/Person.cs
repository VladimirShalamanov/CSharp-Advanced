using System;
using System.Collections.Generic;
using System.Text;

namespace P03ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        public List<string> Bag;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<string>();
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
        public double Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                this.money = value;
            }
        }
    }
}
