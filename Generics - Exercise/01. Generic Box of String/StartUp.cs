using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                var box = new Box<string>(name);
                Console.WriteLine(box);
            }
        }
    }
}
