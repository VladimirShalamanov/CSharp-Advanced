using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] cmds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[,] minerField = new string[n, n];

            int countCoal = 0;
            for (int row = 0; row < minerField.GetLength(0); row++)
            {
                string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < minerField.GetLength(1); col++)
                {
                    minerField[row, col] = arr[col];
                    if (arr[col] == "c")
                        countCoal++;
                }
            }

            for (int i = 0; i < cmds.Length; i++)
            {
                for (int row = 0; row < minerField.GetLength(0); row++)
                {
                    for (int col = 0; col < minerField.GetLength(1); col++)
                    {
                        if (minerField[row, col] == "s")
                        {
                            if (cmds[i] == "left")
                            {
                                if (col - 1 >= 0)
                                {
                                    if (minerField[row, col - 1] == "*")
                                    {
                                        minerField[row, col] = "*";
                                        minerField[row, col - 1] = "s";
                                    }
                                    else if (minerField[row, col - 1] == "c")
                                    {
                                        countCoal--;
                                        minerField[row, col] = "*";
                                        minerField[row, col - 1] = "s";
                                        if (countCoal == 0)
                                        {
                                            Console.WriteLine($"You collected all coals! ({row}, {col - 1})");
                                            return;
                                        }
                                    }
                                    else if (minerField[row, col - 1] == "e")
                                    {
                                        Console.WriteLine($"Game over! ({row}, {col - 1})");
                                        return;
                                    }
                                    if (i == cmds.Length - 1)
                                    {
                                        Console.WriteLine($"{countCoal} coals left. ({row}, {col - 1})");
                                    }
                                    col--;
                                }
                            }
                            else if (cmds[i] == "right")
                            {
                                if (col + 1 < minerField.GetLength(0))
                                {
                                    if (minerField[row, col + 1] == "*")
                                    {
                                        minerField[row, col] = "*";
                                        minerField[row, col + 1] = "s";
                                    }
                                    else if (minerField[row, col + 1] == "c")
                                    {
                                        countCoal--;
                                        minerField[row, col] = "*";
                                        minerField[row, col + 1] = "s";
                                        if (countCoal == 0)
                                        {
                                            Console.WriteLine($"You collected all coals! ({row}, {col + 1})");
                                            return;
                                        }
                                    }
                                    else if (minerField[row, col + 1] == "e")
                                    {
                                        Console.WriteLine($"Game over! ({row}, {col + 1})");
                                        return;
                                    }
                                    if (i == cmds.Length - 1)
                                    {
                                        Console.WriteLine($"{countCoal} coals left. ({row}, {col + 1})");
                                    }
                                    col++;
                                }
                            }
                            else if (cmds[i] == "up")
                            {
                                if (row - 1 >= 0)
                                {
                                    if (minerField[row - 1, col] == "*")
                                    {
                                        minerField[row, col] = "*";
                                        minerField[row - 1, col] = "s";
                                    }
                                    else if (minerField[row - 1, col] == "c")
                                    {
                                        countCoal--;
                                        minerField[row, col] = "*";
                                        minerField[row - 1, col] = "s";
                                        if (countCoal == 0)
                                        {
                                            Console.WriteLine($"You collected all coals! ({row - 1}, {col})");
                                            return;
                                        }
                                    }
                                    else if (minerField[row - 1, col] == "e")
                                    {
                                        Console.WriteLine($"Game over! ({row - 1}, {col})");
                                        return;
                                    }
                                    if (i == cmds.Length - 1)
                                    {
                                        Console.WriteLine($"{countCoal} coals left. ({row - 1}, {col})");
                                    }
                                    row--;
                                }
                            }
                            else if (cmds[i] == "down")
                            {
                                if (row + 1 < minerField.GetLength(1))
                                {
                                    if (minerField[row + 1, col] == "*")
                                    {
                                        minerField[row, col] = "*";
                                        minerField[row + 1, col] = "s";
                                    }
                                    else if (minerField[row + 1, col] == "c")
                                    {
                                        countCoal--;
                                        minerField[row, col] = "*";
                                        minerField[row + 1, col] = "s";
                                        if (countCoal == 0)
                                        {
                                            Console.WriteLine($"You collected all coals! ({row + 1}, {col})");
                                            return;
                                        }
                                    }
                                    else if (minerField[row + 1, col] == "e")
                                    {
                                        Console.WriteLine($"Game over! ({row + 1}, {col})");
                                        return;
                                    }
                                    if (i == cmds.Length - 1)
                                    {
                                        Console.WriteLine($"{countCoal} coals left. ({row + 1}, {col})");
                                    }
                                    row++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
