using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] symbol = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                    matrix[row, col] = symbol[col];
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] arr = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (arr[0] == "swap" && arr.Length == 5)
                {
                    int oneRow = int.Parse(arr[1]);
                    int oneCol = int.Parse(arr[2]);
                    int twoRow = int.Parse(arr[3]);
                    int twoCol = int.Parse(arr[4]);

                    if (oneRow >= 0 && oneRow <= matrix.GetLength(0) - 1 &&
                        oneCol >= 0 && oneCol <= matrix.GetLength(1) - 1 &&
                        twoRow >= 0 && twoRow <= matrix.GetLength(0) - 1 &&
                        twoCol >= 0 && twoCol <= matrix.GetLength(1) - 1)
                    {
                        string oldData = matrix[oneRow, oneCol];
                        string newData = matrix[twoRow, twoCol];
                        matrix[oneRow, oneCol] = newData;
                        matrix[twoRow, twoCol] = oldData;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                                Console.Write(matrix[row, col] + " ");
                            Console.WriteLine();
                        }
                    }
                    else
                    Console.WriteLine("Invalid input!");
                }
                else
                    Console.WriteLine("Invalid input!");
            }
        }
    }
}
