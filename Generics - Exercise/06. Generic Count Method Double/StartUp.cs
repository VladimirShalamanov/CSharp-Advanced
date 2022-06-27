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
            //var list = new List<int>();
            //for (int i = 0; i < n; i++)
            //{
            //    int name = int.Parse(Console.ReadLine());
            //    list.Add(name);
            //}
            //var box = new Box<int>(list);
            //var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //box.Swap(list, indexes[0], indexes[1]);
            //Console.WriteLine(box);

            var list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                var name = double.Parse(Console.ReadLine());
                list.Add(name);
            }
            var box = new Box<double>(list);
            var elToCompare = double.Parse(Console.ReadLine());
            var count = box.CountOfGreater(list, elToCompare);
            Console.WriteLine(count);
        }
    }
}
