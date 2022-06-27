using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                list.Add(name);
            }
            var box = new Box<string>(list);
            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swap(list, indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}
