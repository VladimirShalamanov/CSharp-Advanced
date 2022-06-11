using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                var col = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = col[c];
                }
            }

            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                int sum = 0;
                for (int x = 0; x < matrix.GetLength(0); x++)
                {
                    sum += matrix[x, c];
                }
                Console.WriteLine(sum);
            }

        }
    }
}
