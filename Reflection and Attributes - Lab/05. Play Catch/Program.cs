namespace _05._Play_Catch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = Console.ReadLine().Split().Select(int.Parse).ToList();
            int countExceptions = 0;
            while (countExceptions != 3)
            {
                try
                {
                    string[] param = Console.ReadLine().Split();
                    ReadInput(arr, param);
                    if (param[0] == "Replace") arr[int.Parse(param[1])] = int.Parse(param[2]);
                    else if (param[0] == "Print")
                        Console.WriteLine(string.Join(", ", arr.GetRange(int.Parse(param[1]), int.Parse(param[2]) - int.Parse(param[1]) + 1)));
                    else if (param[0] == "Show") Console.WriteLine(arr[int.Parse(param[1])]);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    countExceptions++;
                }
            }

            Console.WriteLine(string.Join(", ", arr));
        }

        public static void ReadInput(List<int> arr, string[] input)
        {
            if (input.Length == 3 && input[0] == "Print")
            {
                var index = 0;
                var end = 0;
                if (int.TryParse(input[1], out index) &&
                    int.TryParse(input[2], out end))
                {
                    if (index < 0 || index > arr.Count - 1 || end - index + 1 < 0 || end - index + 1 > arr.Count - 1)
                        throw new ArgumentException(ExceptionMesseges.IndexNotEx);
                }
                else
                    throw new ArgumentException(ExceptionMesseges.FormatInNotCorrect);
            }
            else if (input[0] == "Replace" || input[0] == "Show")
            {
                var index = 0;
                if (int.TryParse(input[1], out index))
                {
                    if (index < 0 || index > arr.Count - 1)
                        throw new ArgumentException(ExceptionMesseges.IndexNotEx);
                }
                else
                    throw new ArgumentException(ExceptionMesseges.FormatInNotCorrect);
            }
        }
    }

    public class ExceptionMesseges : Exception
    {
        public const string IndexNotEx = "The index does not exist!";
        public const string FormatInNotCorrect = "The variable is not in the correct format!";
    }
}
