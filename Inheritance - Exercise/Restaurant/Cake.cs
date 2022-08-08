using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double GramsC = 250;
        private const double CaloriesC = 1000;
        private const decimal CakePrice = 5m;

        public Cake(string name) : base(name, CakePrice, GramsC, CaloriesC)
        {

        }
    }
}
