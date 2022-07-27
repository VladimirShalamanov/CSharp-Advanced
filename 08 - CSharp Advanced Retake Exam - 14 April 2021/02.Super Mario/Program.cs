using System;
using System.Linq;

namespace _02.Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] game = new char[n][];
            int r = 0;
            int c = 0;
            for (int row = 0; row < game.GetLength(0); row++)
            {
                string data = Console.ReadLine();
                game[row] = data.ToArray();
                for (int col = 0; col < game[row].Length; col++)
                {
                    game[row][col] = data[col];
                    if (game[row][col] == 'M') { r = row; c = col; }
                }
            }

            while (true)
            {
                string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                char move = char.Parse(arr[0]);
                game[int.Parse(arr[1])][int.Parse(arr[2])] = 'B';

                game[r][c] = '-';
                if (move == 'W') r--;
                else if (move == 'S') r++;
                else if (move == 'A') c--;
                else if (move == 'D') c++;
                lives--;
                if (r < 0) r++;
                else if (r > game.GetLength(0) - 1) r--;
                else if (c < 0) c++;
                else if (c > game.GetLength(0) - 1) c--;

                if (game[r][c] == 'B') lives -= 2;
                if (lives <= 0)
                {
                    game[r][c] = 'X';
                    break;
                }
                else if (game[r][c] == 'P') break;
                else if (game[r][c] == '-') game[r][c] = 'M';
            }
            if (game[r][c] == 'X') Console.WriteLine($"Mario died at {r};{c}.");
            else if (game[r][c] == 'P')
            {
                game[r][c] = '-';
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            for (int row = 0; row < game.GetLength(0); row++)
            {
                for (int col = 0; col < game[row].Length; col++)
                    Console.Write(game[row][col]);
                Console.WriteLine();
            }
        }
    }
}
