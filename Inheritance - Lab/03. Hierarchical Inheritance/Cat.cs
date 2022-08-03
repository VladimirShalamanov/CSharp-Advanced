using System;
using System.Collections.Generic;
using System.Text;

namespace Farm
{
    public class Cat : Animal
    {
        public string cat { get; set; }
        public void Meow()
        {
            Console.WriteLine("meowing…");
        }
    }
}
