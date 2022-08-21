namespace _01._Square_Root
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            double num = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(Sqrt(num));
            }
            catch (Exception aoore)
            {
                Console.WriteLine(aoore.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        public static double Sqrt (double value)
        {
            if (value < 0)
            {
                throw new Exception("Invalid number.");
            }
            return Math.Sqrt(value);
        }
    }
}
