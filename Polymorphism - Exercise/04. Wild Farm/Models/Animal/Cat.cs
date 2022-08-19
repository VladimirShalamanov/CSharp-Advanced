namespace P04.WildFarm.Models.Animal
{
    using P04.WildFarm.Exceptions;
    using P04.WildFarm.Models.Food;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Cat : Feline
    {
        private const double IncreaseWeight = 0.30;
        private ICollection<Type> typeFood = new List<Type> { typeof(Vegetable), typeof(Meat) };
        public Cat(string name, double weight, string livingRegiom, string breed)
            : base(name, weight, livingRegiom, breed)
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
            return "Meow";
        }
    }
}
