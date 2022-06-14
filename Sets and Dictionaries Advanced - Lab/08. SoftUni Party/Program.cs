using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var guests = new HashSet<string>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "PARTY")
                guests.Add(cmd);
            while ((cmd = Console.ReadLine()) != "END")
            {
                if (guests.Contains(cmd))
                    guests.Remove(cmd);
            }
            Console.WriteLine(guests.Count);
            foreach (var guest in guests)
            {
                char[] ch = guest.ToCharArray();
                if (char.IsDigit(ch[0]))
                    Console.WriteLine(guest);
            }
            foreach (var guest in guests)
            {
                char[] ch = guest.ToCharArray();
                if (char.IsLetter(ch[0]))
                    Console.WriteLine(guest);
            }
        }
    }
}
