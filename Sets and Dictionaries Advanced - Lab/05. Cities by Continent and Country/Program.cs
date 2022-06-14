using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var continentData = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = arr[0];
                string country = arr[1];
                string city = arr[2];
                if (!continentData.ContainsKey(continent))
                    continentData[continent] = new Dictionary<string, List<string>>();
                if (!continentData[continent].ContainsKey(country))
                    continentData[continent][country] = new List<string>();
                continentData[continent][country].Add(city);
            }

            foreach (var (continetName, countries) in continentData)
            {
                Console.WriteLine($"{continetName}:");
                foreach (var (countryName, cities) in countries)
                {
                    Console.Write($"  {countryName} -> ");
                    Console.Write($"{string.Join(", ", cities)}");
                    Console.WriteLine();
                }
            }
        }
    }
}
