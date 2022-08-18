using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface ICitizen
    {
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }

        public string Birthdate { get; }
    }
}
