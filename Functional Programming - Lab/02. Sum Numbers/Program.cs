using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Func<string, int> parser = n => int.Parse(n);
            int[] num = input.Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser).ToArray();
            Console.WriteLine(num.Length);
            Console.WriteLine(num.Sum());
        }
    }
}
