namespace _02._Enter_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int totalNums = 10;
            int count = 0;

            var nums = new List<int>();
            while (count != totalNums)
            {
                try
                {
                    int n = int.Parse(Console.ReadLine());
                    if (!nums.Any())
                    {
                        ReadNumber(1, 100, n);
                        nums.Add(n);
                        count++;
                        continue;
                    }

                    ReadNumber(nums[nums.Count - 1], 100, n);
                    nums.Add(n);
                    count++;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Number!");
                }
            }
            Console.WriteLine(string.Join(", ", nums));
        }

        public static void ReadNumber(int start, int end, int n)
        {
            if (n <= start || end <= n)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }
        }
    }
}
