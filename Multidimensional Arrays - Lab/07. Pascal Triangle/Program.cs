using System;

namespace _07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];
            int currWidth = 1;

            for (int row = 0; row < height; row++)
            {
                triangle[row] = new long[currWidth];
                long[] currRow = triangle[row];
                currRow[0] = 1;
                currRow[currRow.Length - 1] = 1;
                currWidth++;
                if (currRow.Length > 2)
                {
                    for (int i = 1; i < currRow.Length - 1; i++)
                    {
                        long[] previousRow = triangle[row - 1];
                        long previousSum = previousRow[i] + previousRow[i - 1];
                        currRow[i] = previousSum;
                    }
                }
            }

            foreach (long[] row in triangle)
                Console.WriteLine(string.Join(" ", row));
        }
    }
}
