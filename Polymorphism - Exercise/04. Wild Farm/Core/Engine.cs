namespace P04.WildFarm.Core
{
    using P04.WildFarm.Factory;
    using P04.WildFarm.Interfaces;
    using P04.WildFarm.IO;
    using P04.WildFarm.Models.Animal;
    using P04.WildFarm.Models.Food;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<IAnimal> listAnimals;
        private CreateFood createFood;
        private object foodCreator;

        private Engine()
        {
            this.listAnimals = new List<IAnimal>();
            this.createFood = new CreateFood();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] inputArguments = command.Split();
                IAnimal animal = null;
                string animalType = inputArguments[0];
                if (animalType == "Owl")
                {
                    animal = new Owl(inputArguments[1], double.Parse(inputArguments[2]), double.Parse(inputArguments[3]));
                }
                else if (animalType == "Hen")
                {
                    animal = new Hen(inputArguments[1], double.Parse(inputArguments[2]), double.Parse(inputArguments[3]));
                }
                else if (animalType == "Mouse")
                {
                    animal = new Mouse(inputArguments[1], double.Parse(inputArguments[2]), inputArguments[3]);
                }
                else if (animalType == "Cat")
                {
                    animal = new Cat(inputArguments[1], double.Parse(inputArguments[2]), inputArguments[3], inputArguments[4]);
                }
                else if (animalType == "Dog")
                {
                    animal = new Dog(inputArguments[1], double.Parse(inputArguments[2]), inputArguments[3]);
                }
                else if (animalType == "Tiger")
                {
                    animal = new Tiger(inputArguments[1], double.Parse(inputArguments[2]), inputArguments[3], inputArguments[4]);
                }
                this.writer.WriteLine(animal.ProduceSound());
                try
                {
                    this.listAnimals.Add(animal);
                    string[] foodArguments = reader.ReadLine().Split();
                    string foodType = foodArguments[0];
                    int quantity = int.Parse(foodArguments[1]);
                    Food food = createFood.Create(foodType, quantity);
                    animal.Feed(food);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
            }

            foreach (var animal in listAnimals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
    }    
}
