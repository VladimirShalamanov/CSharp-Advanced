using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] col = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = col[c];
                }
            }
            int sum = 0;
            for (int r = 0; r < n; r++)
            {
                sum += matrix[r, r];
            }
            Console.WriteLine(sum);
        }
    }
}
