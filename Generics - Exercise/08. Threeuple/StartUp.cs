using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();
            var fullName = $"{personInfo[0]} {personInfo[1]}";
            var address = $"{personInfo[2]}";
            var city = personInfo.Length > 4 ? $"{personInfo[3]} {personInfo[4]}" : $"{personInfo[3]}";

            var nameAndBeer = Console.ReadLine().Split();
            var name = nameAndBeer[0];
            var numOfLiters = int.Parse(nameAndBeer[1]);
            var drunkOrNot = nameAndBeer[2] == "drunk" ? $"True" : $"False";

            var nameAndBank = Console.ReadLine().Split();
            var nameTwo = nameAndBank[0];
            var balance = double.Parse(nameAndBank[1]);
            var bankName = nameAndBank[2];

            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullName, address, city);
            Threeuple<string, int, string> secondTuple = new Threeuple<string, int, string>(name, numOfLiters, drunkOrNot);
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(nameTwo, balance, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
