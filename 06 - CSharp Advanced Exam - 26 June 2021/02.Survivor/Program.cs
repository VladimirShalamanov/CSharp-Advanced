using System;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] beach = new char[n][];
            int countOfCollected = 0;
            int countOfOpponentsTokens = 0;

            for (int row = 0; row < beach.GetLength(0); row++)
            {
                char[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                beach[row] = arr;
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "Gong")
            {
                string[] arr = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string type = arr[0];
                int row = int.Parse(arr[1]);
                int col = int.Parse(arr[2]);
                if (row >= 0 && row < beach.GetLength(0) && col >= 0 && col < beach[row].Length)
                {
                    if (type == "Find")
                    {
                        if (beach[row][col] == 'T') { countOfCollected++; beach[row][col] = '-'; }
                    }
                    else if (type == "Opponent")
                    {
                        string direction = arr[3];
                        int count = -1;
                        if (direction == "up")
                        {
                            for (int r = row; r >= 0; r--)
                            {
                                if (col < beach[r].Length)
                                    if (beach[r][col] == 'T') { countOfOpponentsTokens++; beach[r][col] = '-'; }
                                count++;
                                if (count == 3) break;
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int r = row; r < beach.GetLength(0); r++)
                            {
                                if (col < beach[r].Length)
                                    if (beach[r][col] == 'T') { countOfOpponentsTokens++; beach[r][col] = '-'; }
                                count++;
                                if (count == 3) break;
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int c = col; c >= 0; c--)
                            {
                                if (beach[row][c] == 'T') { countOfOpponentsTokens++; beach[row][c] = '-'; }
                                count++;
                                if (count == 3) break;
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int c = col; c < beach[row].Length; c++)
                            {
                                if (beach[row][c] == 'T') { countOfOpponentsTokens++; beach[row][c] = '-'; }
                                count++;
                                if (count == 3) break;
                            }
                        }
                    }
                }
            }
            for (int row = 0; row < beach.GetLength(0); row++)
            {
                for (int col = 0; col < beach[row].Length; col++)
                {
                    Console.Write(beach[row][col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Collected tokens: {countOfCollected}");
            Console.WriteLine($"Opponent's tokens: {countOfOpponentsTokens}");
        }
    }
}
