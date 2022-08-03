using System;
using System.Collections.Generic;
using System.Text;

namespace Farm
{
    public class Dog : Animal
    {
        public string dog { get; set; }
        public void Bark()
        {
            Console.WriteLine("barking…");
        }
    }
}
