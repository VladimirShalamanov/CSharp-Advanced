using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            var filters = new List<string>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "Print")
            {
                string[] arr = cmd.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string type = arr[0];
                if (type == "Add filter")
                {
                    filters.Add(arr[1] + " " + arr[2]);
                }
                else if (type == "Remove filter")
                {
                    filters.Remove(arr[1] + " " + arr[2]);
                }
            }

            foreach (var filter in filters)
            {
                var commands = filter.Split(' ');

                if (commands[0] == "Starts")
                {
                    guests = guests.Where(p => !p.StartsWith(commands[2])).ToList();
                }
                else if (commands[0] == "Ends")
                {
                    guests = guests.Where(p => !p.EndsWith(commands[2])).ToList();
                }
                else if (commands[0] == "Length")
                {
                    guests = guests.Where(p => p.Length != int.Parse(commands[1])).ToList();
                }
                else if (commands[0] == "Contains")
                {
                    guests = guests.Where(p => !p.Contains(commands[1])).ToList();
                }
            }

            Console.WriteLine(string.Join(' ', guests));
        }
    }
}
