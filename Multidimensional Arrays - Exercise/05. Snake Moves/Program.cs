using System;
using System.Linq;

namespace _05._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[sizes[0], sizes[1]];
            string snake = Console.ReadLine();

            for (int i = 0; i < snake.Length;)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (row % 2 == 0)
                    {

                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            matrix[row, col] = snake[i].ToString();
                            if (i == snake.Length - 1)
                            {
                                i = 0;
                            }
                            else
                                i++;
                        }
                    }
                    else
                    {

                        for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                        {
                            matrix[row, col] = snake[i].ToString();
                            if (i == snake.Length - 1)
                            {
                                i = 0;
                            }
                            else
                                i++;
                        }
                    }
                }
                break;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
