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
                int name = int.Parse(Console.ReadLine());
                var box = new Box<int>(name);
                Console.WriteLine(box);
            }
        }
    }
}
