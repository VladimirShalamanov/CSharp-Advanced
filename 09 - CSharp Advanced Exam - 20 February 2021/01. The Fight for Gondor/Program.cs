using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> listPlates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Stack<int> stackOrcs = new Stack<int>();
            int c = 0;
            while (listPlates.Any() && n != 0)
            {

                List<int> listWave = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                stackOrcs = new Stack<int>(listWave);
                n--;
                c++;
                if (c % 3 == 0)
                {
                    int s = int.Parse(Console.ReadLine());
                    listPlates.Insert(listPlates.Count - 1, s);
                }
                while (stackOrcs.Any() && listPlates.Any())
                {
                    int plate = listPlates.First();
                    listPlates.RemoveAt(0);
                    int orc = stackOrcs.Pop();
                    if (plate > orc)
                    {
                        plate -= orc;
                        orc = 0;
                        listPlates.Insert(0, plate);
                    }
                    else if (plate < orc)
                    {
                        orc -= plate;
                        plate = 0;
                        stackOrcs.Push(orc);
                    }
                    else if (plate == orc)
                    {
                        plate = 0;
                        orc = 0;
                    }
                }

            }
            if (listPlates.Any())
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine("Plates left: " + string.Join(", ", listPlates));
            }
            else if (stackOrcs.Any())
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            Console.WriteLine("Orcs left: " + string.Join(", ", stackOrcs));
            }
        }
    }
}
