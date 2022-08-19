namespace P04.WildFarm.Factory
{
    using P04.WildFarm.Models.Food;
    using System;

    public class CreateFood
    {
        public Food Create(string type, int quantity)
        {
            Food food = null;
            if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (type == null)
            {
                throw new ArgumentNullException();
            }
            return food;
        }
    }
}
