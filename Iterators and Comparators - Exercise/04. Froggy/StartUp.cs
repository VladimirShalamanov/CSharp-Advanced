﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lake
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lake = new Lake(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
