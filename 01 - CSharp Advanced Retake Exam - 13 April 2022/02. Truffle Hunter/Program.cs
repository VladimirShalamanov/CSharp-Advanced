using System;
using System.Linq;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] forest = new string[n, n];

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                string[] ch = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < forest.GetLength(1); col++)
                    forest[row, col] = ch[col];
            }


            int blackTruffle = 0;
            int summerTruffle = 0;
            int whiteTruffle = 0;
            int wildBoar = 0;
            string cmd;
            while ((cmd = Console.ReadLine()) != "Stop the hunt")
            {
                string[] arr = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (arr.Length == 3)
                {
                    if (arr[0] == "Collect")
                    {
                        if (int.TryParse(arr[1], out int rowInput))
                        {
                            if (int.TryParse(arr[2], out int colInput))
                            {
                                if (rowInput >= 0 && rowInput < forest.GetLength(0) &&
                                    colInput >= 0 && colInput < forest.GetLength(1))
                                {
                                    if (forest[rowInput, colInput] == "B")
                                    {
                                        blackTruffle++;
                                        forest[rowInput, colInput] = "-";
                                    }
                                    else if (forest[rowInput, colInput] == "S")
                                    {
                                        summerTruffle++;
                                        forest[rowInput, colInput] = "-";
                                    }
                                    else if (forest[rowInput, colInput] == "W")
                                    {
                                        whiteTruffle++;
                                        forest[rowInput, colInput] = "-";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (arr.Length == 4)
                {
                    if (arr[0] == "Wild_Boar")
                    {
                        if (int.TryParse(arr[1], out int rowInput))
                        {
                            if (int.TryParse(arr[2], out int colInput))
                            {
                                if (rowInput >= 0 && rowInput < forest.GetLength(0) &&
                                    colInput >= 0 && colInput < forest.GetLength(1))
                                {
                                    if (arr[3] == "up")
                                    {
                                        for (int i = rowInput; i >= 0; i--)
                                        {
                                            if (forest[i, colInput] == "B" ||
                                                forest[i, colInput] == "S" ||
                                                forest[i, colInput] == "W")
                                            {
                                                wildBoar++;
                                                forest[i, colInput] = "-";
                                            }
                                            i--;
                                        }
                                    }
                                    else if (arr[3] == "down")
                                    {
                                        for (int i = rowInput; i < forest.GetLength(0); i++)
                                        {
                                            if (forest[i, colInput] == "B" ||
                                                forest[i, colInput] == "S" ||
                                                forest[i, colInput] == "W")
                                            {
                                                wildBoar++;
                                                forest[i, colInput] = "-";
                                            }
                                            i++;
                                        }
                                    }
                                    else if (arr[3] == "left")
                                    {
                                        for (int i = colInput; i >= 0; i--)
                                        {
                                            if (forest[rowInput, i] == "B" ||
                                                forest[rowInput, i] == "S" ||
                                                forest[rowInput, i] == "W")
                                            {
                                                wildBoar++;
                                                forest[rowInput, i] = "-";
                                            }
                                            i--;
                                        }
                                    }
                                    else if (arr[3] == "right")
                                    {
                                        for (int i = colInput; i < forest.GetLength(1); i++)
                                        {
                                            if (forest[rowInput, i] == "B" ||
                                                forest[rowInput, i] == "S" ||
                                                forest[rowInput, i] == "W")
                                            {
                                                wildBoar++;
                                                forest[rowInput, i] = "-";
                                            }
                                            i++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffle} black, {summerTruffle} summer, and {whiteTruffle} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoar} truffles.");

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    Console.Write(forest[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}