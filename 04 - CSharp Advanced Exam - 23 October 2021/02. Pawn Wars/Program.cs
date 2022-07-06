using System;
using System.Collections.Generic;

namespace _02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chessboard = new string[8, 8];
            var coordinates = new string[8, 8];
            var words = "abcdefgh";
            var nums = "87654321";
            var pawn = new List<char>() { 'w', 'b' };
            int wRow = 0;
            int wCol = 0;
            int bRow = 0;
            int bCol = 0;

            for (int row = 0; row < chessboard.GetLength(0); row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < chessboard.GetLength(1); col++)
                {
                    chessboard[row, col] = data[col].ToString();
                    coordinates[row, col] = words[col].ToString() + nums[row].ToString();
                    if (chessboard[row, col] == "w")
                    {
                        wRow = row;
                        wCol = col;
                    }
                    else if (chessboard[row, col] == "b")
                    {
                        bRow = row;
                        bCol = col;
                    }
                }
            }
            int move = 0;
            while (pawn.Count > 1)
            {
                move++;
                if (move % 2 != 0)
                {
                    if (wRow - 1 >= 0 && wCol - 1 >= 0)
                    {
                        if (chessboard[wRow - 1, wCol - 1] == "b")
                        {
                            chessboard[wRow, wCol] = "-";
                            wRow--;
                            wCol--;
                            chessboard[wRow, wCol] = "w";
                            pawn.Remove('b');
                            continue;
                        }
                    }
                    if (wRow - 1 >= 0 && wCol + 1 < chessboard.GetLength(1))
                    {
                        if (chessboard[wRow - 1, wCol + 1] == "b")
                        {
                            chessboard[wRow, wCol] = "-";
                            wRow--;
                            wCol++;
                            chessboard[wRow, wCol] = "w";
                            pawn.Remove('b');
                            continue;
                        }
                    }
                    chessboard[wRow, wCol] = "-";
                    wRow--;
                    chessboard[wRow, wCol] = "w";
                    if (wRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {coordinates[wRow, wCol]}.");
                        return;
                    }
                }
                else
                {
                    if (bRow + 1 < chessboard.GetLength(0) && bCol + 1 < chessboard.GetLength(1))
                    {
                        if (chessboard[bRow + 1, bCol + 1] == "w")
                        {
                            chessboard[bRow, bCol] = "-";
                            bRow++;
                            bCol++;
                            chessboard[bRow, bCol] = "b";
                            pawn.Remove('w');
                            continue;
                        }
                    }
                    if (bRow + 1 < chessboard.GetLength(0) && bCol - 1 >= 0)
                    {
                        if (chessboard[bRow + 1, bCol - 1] == "w")
                        {
                            chessboard[bRow, bCol] = "-";
                            bRow++;
                            bCol--;
                            chessboard[bRow, bCol] = "b";
                            pawn.Remove('w');
                            continue;
                        }
                    }
                    chessboard[bRow, bCol] = "-";
                    bRow++;
                    chessboard[bRow, bCol] = "b";
                    if (bRow == chessboard.GetLength(0) - 1)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {coordinates[bRow, bCol]}.");
                        return;
                    }
                }
            }
            if (pawn.Contains('w')) Console.WriteLine($"Game over! White capture on {coordinates[wRow, wCol]}.");
            else if (pawn.Contains('b')) Console.WriteLine($"Game over! Black capture on {coordinates[bRow, bCol]}.");
        }
    }
}