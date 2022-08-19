namespace P04.WildFarm.Interfaces
{
    using P04.WildFarm.Models.Food;

    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        public void Feed(Food food);
        public string ProduceSound();
    }
}
