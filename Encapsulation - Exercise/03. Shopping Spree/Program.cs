using System;
using System.Collections.Generic;
using System.Linq;

namespace P03ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] personsArr = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] productsArr = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var people = new Dictionary<string, Person>();
            try
            {
                for (int i = 0; i < personsArr.Length; i++)
                {
                    string[] p = personsArr[i].Split('=', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    Person personClass = new Person(p[0], double.Parse(p[1]));
                    people[p[0]] = personClass;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            var products = new Dictionary<string, Product>();
            try
            {
                for (int i = 0; i < productsArr.Length; i++)
                {
                    string[] p = productsArr[i].Split('=', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    Product productClass = new Product(p[0], int.Parse(p[1]));
                    products[p[0]] = productClass;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] arr = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = arr[0];
                string product = arr[1];

                double money = people[name].Money;
                double cost = products[product].Cost;

                if (money - cost < 0) Console.WriteLine($"{name} can't afford {product}");
                else
                {
                    people[name].Money -= cost;
                    Console.WriteLine($"{name} bought {product}");
                    people[name].Bag.Add(product);
                }
            }

            foreach (var person in people)
            {
                if (person.Value.Bag.Count == 0) Console.WriteLine($"{person.Key} - Nothing bought");
                else Console.WriteLine($"{person.Key} - {string.Join(", ", person.Value.Bag)}");
            }
        }
    }
}
