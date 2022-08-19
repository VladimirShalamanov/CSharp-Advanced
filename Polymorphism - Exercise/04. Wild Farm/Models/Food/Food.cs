namespace P04.WildFarm.Models.Food
{
    using P04.WildFarm.Interfaces;

    public class Food : IFood
    {
        public int Quantity { get; private set; }

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
