﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();
            Action<string> printSir = name => Console.WriteLine("Sir " + name);
            list.ForEach(printSir);
        }
    }
}
