using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Func<string, int> parser = n => int.Parse(n);
            int[] num = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(parser).ToArray();
            Console.WriteLine(num.Min());
        }
    }
}
