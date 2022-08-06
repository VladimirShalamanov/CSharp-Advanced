using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = arr[0];
                    int age = int.Parse(arr[1]);

                    Animal animal = null;
                    if (cmd == "Dog")
                    {
                        string gender = arr[2];
                        animal = new Dog(name, age, gender);
                    }
                    else if (cmd == "Cat")
                    {
                        string gender = arr[2];
                        animal = new Cat(name, age, gender);
                    }
                    else if (cmd == "Frog")
                    {
                        string gender = arr[2];
                        animal = new Frog(name, age, gender);
                    }
                    else if (cmd == "Kittens")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (cmd == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid input!");
                    }

                    animals.Add(animal);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            foreach (Animal item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
