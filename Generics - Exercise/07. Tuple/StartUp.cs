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
            var city = $"{personInfo[2]}";

            var nameAndBeer = Console.ReadLine().Split();
            var name = nameAndBeer[0];
            var numOfLiters = int.Parse(nameAndBeer[1]);

            var numInput = Console.ReadLine().Split();
            var intNum = int.Parse(numInput[0]);
            var doubleNum = double.Parse(numInput[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, city);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, numOfLiters);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
