using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            if (n == 0) return;
            char[][] middleWorld = new char[n][];
            var army = new List<int>() { 0, 0 };

            for (int row = 0; row < middleWorld.GetLength(0); row++)
            {
                char[] field = Console.ReadLine().ToCharArray();
                middleWorld[row] = field;
                for (int col = 0; col < field.Length; col++)
                {
                    if (middleWorld[row][col] == 'A') { army[0] = row; army[1] = col; }
                }
            }
            middleWorld[army[0]][army[1]] = '-';
            bool gameOver = false;
            if (armor <= 0) { middleWorld[army[0]][army[1]] = 'X'; gameOver = true; }

            while (gameOver == false)
            {
                string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string move = arr[0];
                int row = int.Parse(arr[1]); int col = int.Parse(arr[2]);
                middleWorld[row][col] = 'O';
                armor--;
                if (move == "up")
                {
                    if (army[0] - 1 >= 0)
                    {
                        army[0]--;
                        if (armor <= 0 && middleWorld[army[0]][army[1]] != 'M')
                        {
                            middleWorld[army[0]][army[1]] = 'X';
                            gameOver = true;
                        }
                        if (middleWorld[army[0]][army[1]] == 'O')
                        {
                            armor -= 2;
                            if (armor <= 0) { middleWorld[army[0]][army[1]] = 'X'; gameOver = true; }
                            else middleWorld[army[0]][army[1]] = '-';
                        }
                        else if (middleWorld[army[0]][army[1]] == 'M') { middleWorld[army[0]][army[1]] = '-'; gameOver = true; }
                    }
                    else
                    {
                        if (armor <= 0) { middleWorld[army[0]][army[1]] = 'X'; gameOver = true; }
                    }
                }
                else if (move == "down")
                {
                    if (army[0] + 1 < middleWorld.GetLength(0))
                    {
                        army[0]++;
                        if (armor <= 0 && middleWorld[army[0]][army[1]] != 'M')
                        {
                            middleWorld[army[0]][army[1]] = 'X';
                            gameOver = true;
                        }
                        if (middleWorld[army[0]][army[1]] == 'O')
                        {
                            armor -= 2;
                            if (armor <= 0) { middleWorld[army[0]][army[1]] = 'X'; gameOver = true; }
                            else middleWorld[army[0]][army[1]] = '-';
                        }
                        else if (middleWorld[army[0]][army[1]] == 'M') { middleWorld[army[0]][army[1]] = '-'; gameOver = true; }
                    }
                    else
                    {
                        if (armor <= 0) { middleWorld[army[0]][army[1]] = 'X'; gameOver = true; }
                    }
                }
                else if (move == "left")
                {
                    if (army[1] - 1 >= 0)
                    {
                        army[1]--;
                        if (armor <= 0 && middleWorld[army[0]][army[1]] != 'M')
                        {
                            middleWorld[army[0]][army[1]] = 'X';
                            gameOver = true;
                        }
                        if (middleWorld[army[0]][army[1]] == 'O')
                        {
                            armor -= 2;
                            if (armor <= 0) { middleWorld[army[0]][army[1]] = 'X'; gameOver = true; }
                            else middleWorld[army[0]][army[1]] = '-';
                        }
                        else if (middleWorld[army[0]][army[1]] == 'M') { middleWorld[army[0]][army[1]] = '-'; gameOver = true; }
                    }
                    else
                    {
                        if (armor <= 0) { middleWorld[army[0]][army[1]] = 'X'; gameOver = true; }
                    }
                }
                else if (move == "right")
                {
                    if (army[1] + 1 < middleWorld.GetLength(0))
                    {
                        army[1]++;
                        if (armor <= 0 && middleWorld[army[0]][army[1]] != 'M')
                        {
                            middleWorld[army[0]][army[1]] = 'X';
                            gameOver = true;
                        }
                        if (middleWorld[army[0]][army[1]] == 'O')
                        {
                            armor -= 2;
                            if (armor <= 0) { middleWorld[army[0]][army[1]] = 'X'; gameOver = true; }
                            else middleWorld[army[0]][army[1]] = '-';
                        }
                        else if (middleWorld[army[0]][army[1]] == 'M') { middleWorld[army[0]][army[1]] = '-'; gameOver = true; }
                    }
                    else
                    {
                        if (armor <= 0) { middleWorld[army[0]][army[1]] = 'X'; gameOver = true; }
                    }
                }
            }

            if (middleWorld[army[0]][army[1]] == 'X') Console.WriteLine($"The army was defeated at {army[0]};{army[1]}.");
            else if (middleWorld[army[0]][army[1]] == '-') Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");

            for (int row = 0; row < middleWorld.GetLength(0); row++)
            {
                for (int col = 0; col < middleWorld[row].Length; col++)
                    Console.Write(middleWorld[row][col]);
                Console.WriteLine();
            }
        }
    }
}
