using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[row] = nums;
            }

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                string[] tokens = line.Split();
                string cmd = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row < 0 || row >= matrix.Length
                    || col < 0 || col >= matrix.Length)
                    Console.WriteLine("Invalid coordinates");
                else
                {
                    if (cmd == "Add")
                        matrix[row][col] += value;
                    if (cmd == "Subtract")
                        matrix[row][col] -= value;
                }
            }

            foreach (int[] row in matrix)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
