namespace P04.WildFarm.Models.Animal
{
    using P04.WildFarm.Exceptions;
    using P04.WildFarm.Models.Food;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Owl : Bird
    {
        private const double IncreaseWeight = 0.25;
        private ICollection<Type> typeFood = new List<Type> { typeof(Meat) };
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Feed(Food food)
        {
            if (!typeFood.Any(f => f.Name == food.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionsMesseges.InvalidFoodException,
                    this.GetType().Name, food.GetType().Name));
            }
            base.Weight += food.Quantity * IncreaseWeight;
            base.FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
