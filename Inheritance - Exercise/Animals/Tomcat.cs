using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string GenderT = "Female";
        public Tomcat(string name, int age) : base(name, age, GenderT)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
