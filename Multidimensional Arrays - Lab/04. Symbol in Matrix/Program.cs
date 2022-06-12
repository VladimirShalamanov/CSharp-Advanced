using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string symbols = Console.ReadLine();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = symbols[c];
                }
            }

            char s = char.Parse(Console.ReadLine());

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == s)
                    {
                        Console.WriteLine($"({r}, {c})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{s} does not occur in the matrix");
        }
    }
}
