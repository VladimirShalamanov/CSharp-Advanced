using System;
using System.Collections.Generic;

namespace _02._Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var armory = new char[n, n];
            int r = 0;
            int c = 0;
            int minimumCoins = 65;
            int totalCoins = 0;
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                char[] arr = Console.ReadLine().ToCharArray();
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    armory[row, col] = arr[col];
                    if (armory[row, col] == 'A')
                    {
                        r = row;
                        c = col;
                    }
                }
            }
            bool isOutSide = false;
            while (true)
            {
                string direction = Console.ReadLine();
                if (direction == "up")
                {
                    if (!IsInside(r - 1, c, armory))
                    {
                        armory[r, c] = '-';
                        isOutSide = true;
                        break;
                    }
                    armory[r, c] = '-';
                    r--;
                    if (char.IsDigit(armory[r, c]))
                    {
                        int price = int.Parse((armory[r, c]).ToString());
                        totalCoins += price;
                        armory[r, c] = 'A';
                    }
                    else if (armory[r, c] == 'M')
                    {
                        armory[r, c] = '-';
                        List<int> nums = GetSecondM(armory);
                        r = nums[0];
                        c = nums[1];
                        armory[r, c] = 'A';
                    }
                }
                else if (direction == "down")
                {
                    if (!IsInside(r + 1, c, armory))
                    {
                        armory[r, c] = '-';
                        isOutSide = true;
                        break;
                    }
                    armory[r, c] = '-';
                    r++;
                    if (char.IsDigit(armory[r, c]))
                    {
                        int price = int.Parse((armory[r, c]).ToString());
                        totalCoins += price;
                        armory[r, c] = 'A';
                    }
                    else if (armory[r, c] == 'M')
                    {
                        armory[r, c] = '-';
                        List<int> nums = GetSecondM(armory);
                        r = nums[0];
                        c = nums[1];
                        armory[r, c] = 'A';
                    }
                }
                else if (direction == "right")
                {
                    if (!IsInside(r, c + 1, armory))
                    {
                        armory[r, c] = '-';
                        isOutSide = true;
                        break;
                    }
                    armory[r, c] = '-';
                    c++;
                    if (char.IsDigit(armory[r, c]))
                    {
                        int price = int.Parse((armory[r, c]).ToString());
                        totalCoins += price;
                        armory[r, c] = 'A';
                    }
                    else if (armory[r, c] == 'M')
                    {
                        armory[r, c] = '-';
                        List<int> nums = GetSecondM(armory);
                        r = nums[0];
                        c = nums[1];
                        armory[r, c] = 'A';
                    }
                }
                else if (direction == "left")
                {
                    if (!IsInside(r, c - 1, armory))
                    {
                        armory[r, c] = '-';
                        isOutSide = true;
                        break;
                    }
                    armory[r, c] = '-';
                    c--;
                    if (char.IsDigit(armory[r, c]))
                    {
                        int price = int.Parse((armory[r, c]).ToString());
                        totalCoins += price;
                        armory[r, c] = 'A';
                    }
                    else if (armory[r, c] == 'M')
                    {
                        armory[r, c] = '-';
                        List<int> nums = GetSecondM(armory);
                        r = nums[0];
                        c = nums[1];
                        armory[r, c] = 'A';
                    }
                }
                if (totalCoins >= minimumCoins)
                {
                    break;
                }
            }
            if (isOutSide == true) Console.WriteLine("I do not need more swords!");
            else Console.WriteLine($"Very nice swords, I will come back for more!");

            Console.WriteLine($"The king paid {totalCoins} gold coins.");
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                    Console.Write(armory[row, col]);
                Console.WriteLine();
            }
        }
        public static bool IsInside(int row, int col, char[,] armory)
        {
            return row >= 0 && row < armory.GetLength(0) &&
                   col >= 0 && col < armory.GetLength(1);
        }
        public static List<int> GetSecondM(char[,] armory)
        {
            List<int> nums = new List<int>();
            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    if (armory[row, col] == 'M')
                    {
                        nums.Add(row);
                        nums.Add(col);
                        break;
                    }
                    if (nums.Count > 0) break;
                }
            }
            return nums;
        }
    }
}
