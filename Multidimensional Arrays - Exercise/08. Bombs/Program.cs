using System;
using System.Linq;

namespace _08._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] battlefield = new int[n, n];

            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < battlefield.GetLength(1); col++)
                    battlefield[row, col] = arr[col];
            }

            string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < info.Length; i++)
            {
                int[] coordinates = info[i].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int row = 0; row < battlefield.GetLength(0); row++)
                {
                    for (int col = 0; col < battlefield.GetLength(1); col++)
                    {
                        if (row == coordinates[0] && col == coordinates[1])
                        {
                            if (battlefield[row, col] > 0)
                            {
                                int bomb = battlefield[row, col];
                                battlefield[row, col] = 0;
                                if (row - 1 >= 0)
                                {
                                    if (battlefield[row - 1, col] > 0)
                                        battlefield[row - 1, col] -= bomb;
                                }
                                if (row + 1 < battlefield.GetLength(0))
                                {
                                    if (battlefield[row + 1, col] > 0)
                                        battlefield[row + 1, col] -= bomb;
                                }
                                if (col - 1 >= 0)
                                {
                                    if (battlefield[row, col - 1] > 0)
                                        battlefield[row, col - 1] -= bomb;
                                }
                                if (col + 1 < battlefield.GetLength(1))
                                {
                                    if (battlefield[row, col + 1] > 0)
                                        battlefield[row, col + 1] -= bomb;
                                }
                                if (row - 1 >= 0 && col - 1 >= 0)
                                {
                                    if (battlefield[row - 1, col - 1] > 0)
                                        battlefield[row - 1, col - 1] -= bomb;
                                }
                                if (row + 1 < battlefield.GetLength(0) && col + 1 < battlefield.GetLength(1))
                                {
                                    if (battlefield[row + 1, col + 1] > 0)
                                        battlefield[row + 1, col + 1] -= bomb;
                                }
                                if (col - 1 >= 0 && row + 1 < battlefield.GetLength(0))
                                {
                                    if (battlefield[row + 1, col - 1] > 0)
                                        battlefield[row + 1, col - 1] -= bomb;
                                }
                                if (col + 1 < battlefield.GetLength(1) && row - 1 >= 0)
                                {
                                    if (battlefield[row - 1, col + 1] > 0)
                                        battlefield[row - 1, col + 1] -= bomb;
                                }
                            }
                        }
                    }
                }
            }

            int count = 0;
            int sum = 0;
            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                for (int col = 0; col < battlefield.GetLength(1); col++)
                {
                    if (battlefield[row, col] > 0)
                    {
                        count++;
                        sum += battlefield[row, col];
                    }
                }
            }

            Console.WriteLine("Alive cells: " + count);
            Console.WriteLine("Sum: " + sum);

            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                for (int col = 0; col < battlefield.GetLength(1); col++)
                    Console.Write(battlefield[row, col] + " ");
                Console.WriteLine();
            }
        }
    }
}
