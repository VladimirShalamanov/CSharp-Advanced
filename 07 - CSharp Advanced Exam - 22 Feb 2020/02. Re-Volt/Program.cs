using System;

namespace _02._Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countCmd = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int r = 0;
            int c = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string arr = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                    if (matrix[row, col] == 'f') { r = row; c = col; }
                }
            }

            while (countCmd != 0)
            {
                string move = Console.ReadLine();
                int row = r;
                int col = c;
                matrix[row, col] = '-';
                if (move == "up") row--;
                else if (move == "down") row++;
                else if (move == "left") col--;
                else if (move == "right") col++;
                //----------------------------------------------
                if (row < 0) row = matrix.GetLength(0) - 1;
                else if (row > matrix.GetLength(0) - 1) row = 0;
                else if (col < 0) col = matrix.GetLength(1) - 1;
                else if (col > matrix.GetLength(1) - 1) col = 0;
                //----------------------------------------------
                if (matrix[row, col] == 'B')
                {
                    if (move == "up") row--;
                    else if (move == "down") row++;
                    else if (move == "left") col--;
                    else if (move == "right") col++;
                    if (row < 0) row = matrix.GetLength(0) - 1;
                    else if (row > matrix.GetLength(0) - 1) row = 0;
                    else if (col < 0) col = matrix.GetLength(1) - 1;
                    else if (col > matrix.GetLength(1) - 1) col = 0;
                }
                else if (matrix[row, col] == 'T')
                {
                    row = r;
                    col = c;
                }
                if (matrix[row, col] == 'F')
                {
                    r = row;
                    c = col;
                    break;
                }
                if (matrix[row, col] == '-') matrix[row, col] = 'f';
                r = row;
                c = col;
                countCmd--;
            }

            if (matrix[r, c] == 'F')
            {
                matrix[r, c] = 'f';
                Console.WriteLine("Player won!");
            }
            else Console.WriteLine("Player lost!");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                    Console.Write(matrix[row, col]);
                Console.WriteLine();
            }
        }
    }
}
