namespace P04.WildFarm.Models.Animal
{
    using P04.WildFarm.Exceptions;
    using P04.WildFarm.Models.Food;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Mouse : Mammal
    {
        private const double IncreaseWeight = 0.10;
        private ICollection<Type> typeFood = new List<Type> { typeof(Vegetable), typeof(Fruit) };
        public Mouse(string name, double weight, string livingRegiom)
            : base(name, weight, livingRegiom)
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
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{base.ToString()} {base.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
