using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];

            for (int row = 0; row < matrix.Length; row++)
                matrix[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                        matrix[row][col] /= 2;
                    for (int col = 0; col < matrix[row + 1].Length; col++)
                        matrix[row + 1][col] /= 2;
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] inputArgs = cmd.Split();
                string command = inputArgs[0];
                int row = int.Parse(inputArgs[1]);
                int col = int.Parse(inputArgs[2]);
                int value = int.Parse(inputArgs[3]);

                if (row >= 0 && row < matrix.Length)
                {
                    if (col >= 0 && col < matrix[row].Length)
                    {
                        if (command == "Add")
                        {
                            matrix[row][col] += value;
                        }
                        else if (command == "Subtract")
                        {
                            matrix[row][col] -= value;
                        }
                    }
                    else continue;
                }
                else continue;
            }

            foreach (var arr in matrix)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
