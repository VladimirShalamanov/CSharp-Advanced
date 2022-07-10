using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[arr[0], arr[1]];
            int maxSum = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            for (int r = 0; r < matrix.GetLength(0) - 2; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 2; c++)
                {
                    var sum = matrix[r, c] +
                              matrix[r + 1, c] +
                              matrix[r, c + 1] +
                              matrix[r + 1, c + 1] +
                              matrix[r + 2, c] +
                              matrix[r, c + 2] +
                              matrix[r + 2, c + 1] +
                              matrix[r + 1, c + 2] +
                              matrix[r + 2, c + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestRow = r;
                        bestCol = c;
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);
            for (int row = bestRow; row <= bestRow + 2; row++)
            {
                for (int col = bestCol; col <= bestCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
