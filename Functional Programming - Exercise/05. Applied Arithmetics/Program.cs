using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Func<List<int>, List<int>> func = null;
            Action<List<int>> print = list => Console.WriteLine(string.Join(" ", list));

            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                switch (cmd)
                {
                    case "add":
                        func = list => list.Select(n => n += 1).ToList();
                        list = func(list);
                        break;
                    case "multiply":
                        func = list => list.Select(n => n *= 2).ToList();
                        list = func(list);
                        break;
                    case "subtract":
                        func = list => list.Select(n => n -= 1).ToList();
                        list = func(list);
                        break;
                    case "print":
                        print(list);
                        break;
                }
            }
        }
    }
}
