namespace _06._Money_Transactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(',').ToArray();
            var dict = new Dictionary<int, double>();
            for (int i = 0; i < str.Length; i++)
            {
                string[] arr = str[i].Split('-');
                dict.Add(int.Parse(arr[0]), double.Parse(arr[1]));
            }
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                try
                {
                    ReadParam(cmd, dict);
                    int acc = int.Parse(cmd.Split()[1]);
                    Console.WriteLine($"Account {acc} has new balance: {dict[acc]:f2}");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                Console.WriteLine("Enter another command");
            }
        }

        public static void ReadParam(string cmd, Dictionary<int, double> dict)
        {
            string[] arr = cmd.Split();
            int account = 0;
            double balance = 0;
            if (arr[0] == "Deposit" && int.TryParse(arr[1], out account) && double.TryParse(arr[2], out balance))
            {
                if (dict.ContainsKey(account))
                {
                    dict[account] += balance;
                }
                else
                    throw new ArgumentException(ExceptionMesseges.InvalidAccount);
            }
            else if (arr[0] == "Withdraw" && int.TryParse(arr[1], out account) && double.TryParse(arr[2], out balance))
            {
                if (dict.ContainsKey(account))
                {
                    if (dict[account] >= balance)
                    {
                        dict[account] -= balance;
                    }
                    else
                        throw new ArgumentException(ExceptionMesseges.InsufficientBalance);
                }
                else
                    throw new ArgumentException(ExceptionMesseges.InvalidAccount);
            }
            else
                throw new ArgumentException(ExceptionMesseges.InvalidCommand);
        }

        public class ExceptionMesseges : Exception
        {
            public const string InvalidCommand = "Invalid command!";
            public const string InvalidAccount = "Invalid account!";
            public const string InsufficientBalance = "Insufficient balance!";
        }
    }
}
