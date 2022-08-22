namespace _04._Sum_of_Integers
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            string[] arr = Console.ReadLine().Split();
            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    ReadNumber(arr[i]);
                    sum += int.Parse(arr[i]);
                }
                catch (OverflowException ofe)
                {
                    Console.WriteLine(ofe.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }

                Console.WriteLine($"Element '{arr[i]}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }

        public static void ReadNumber(string n)
        {
            if (string.IsNullOrEmpty(n))
            {
                throw new FormatException($"The element '{n}' is in wrong format!");
            }
            for (int i = 0; i < n.Length; i++)
            {
                if (!char.IsDigit(n[i]) && n[i] != '-')
                {
                    throw new FormatException($"The element '{n}' is in wrong format!");
                }
            }
            int num;
            if (!int.TryParse(n, out num))
            {
                throw new OverflowException($"The element '{n}' is out of range!");
            }
        }
    }
}
