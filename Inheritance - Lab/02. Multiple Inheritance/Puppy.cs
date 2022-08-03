using System;
using System.Collections.Generic;
using System.Text;

namespace Farm
{
    public class Puppy : Dog
    {
        public string puppy { get; set; }
        public void Weep()
        {
            Console.WriteLine("weeping…");
        }
    }
}
