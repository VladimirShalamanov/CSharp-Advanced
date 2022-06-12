using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[num[0], num[1]];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = nums[c];
                }
            }

            int maxSum = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    var sum = matrix[r, c] +
                                        matrix[r + 1, c] +
                                        matrix[r, c + 1] +
                                        matrix[r + 1, c + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestRow = r;
                        bestCol = c;
                    }
                }
            }

            Console.WriteLine(
                matrix[bestRow, bestCol] + " " +
                matrix[bestRow, bestCol + 1]);
            Console.WriteLine(
                matrix[bestRow + 1, bestCol] + " " +
                matrix[bestRow + 1, bestCol + 1]);
            Console.WriteLine(maxSum);
        }
    }
}
