namespace P04.WildFarm.Models.Animal
{
    using P04.WildFarm.Models.Food;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Hen : Bird
    {
        private const double IncreaseWeight = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Feed(Food food)
        {
            base.Weight += food.Quantity * IncreaseWeight;
            base.FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
