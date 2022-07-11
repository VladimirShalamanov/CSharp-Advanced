using System;

namespace _07._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string arr = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                    matrix[row, col] = arr[col].ToString();
            }

            int knightsInDangerCounter = 0;
            int removedKnightsCounter = 0;

            for (int maxAttackPotential = 8; maxAttackPotential > 0; maxAttackPotential--) // Every knight can attack and kill maximum 8 other knights. P.S. Check "Possible moves" at the beginning.
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col].ToLower() == "k") // Check if we have knight on current position.
                        {
                            // Check if new position isn't outside of the board (so we don't get IndexOutOfRangeException).
                            if (row - 1 >= 0)
                            {
                                if (col - 2 >= 0)
                                {
                                    // Check if there is knight to be attacked on the new possition.
                                    if (matrix[row - 1, col - 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 2 < matrix.GetLength(1))
                                {
                                    // Check if there is knight to be attacked on the new possition.
                                    if (matrix[row - 1, col + 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }

                            if (row + 1 < matrix.GetLength(0))
                            {
                                if (col - 2 >= 0)
                                {
                                    // Check if there is knight to be attacked on the new possition
                                    if (matrix[row + 1, col - 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 2 < matrix.GetLength(1))
                                {
                                    // Check if there is knight to be attacked on the new possition
                                    if (matrix[row + 1, col + 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }

                            if (row - 2 >= 0)
                            {
                                if (col - 1 >= 0)
                                {
                                    // Check if there is knight to be attacked on the new possition
                                    if (matrix[row - 2, col - 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 1 < matrix.GetLength(1))
                                {
                                    // Check if there is knight to be attacked on the new possition
                                    if (matrix[row - 2, col + 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }

                            if (row + 2 < matrix.GetLength(0))
                            {
                                if (col - 1 >= 0)
                                {
                                    // Check if there is knight to be attacked on the new possition
                                    if (matrix[row + 2, col - 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 1 < matrix.GetLength(1))
                                {
                                    // Check if there is knight to be attacked on the new possition
                                    if (matrix[row + 2, col + 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }
                        }

                        // Check if every possible attack is against another knight (attack potential of current knight is biggest possible)
                        if (knightsInDangerCounter == maxAttackPotential)
                        {
                            matrix[row, col] = "0"; // Remove knight from board.
                            removedKnightsCounter++;
                        }

                        knightsInDangerCounter = 0; // Restart counter.
                    }
                }
            }

            // Print result
            Console.WriteLine(removedKnightsCounter);
        }
    }
}
