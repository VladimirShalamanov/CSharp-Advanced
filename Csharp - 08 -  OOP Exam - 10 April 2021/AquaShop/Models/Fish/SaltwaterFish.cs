namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int InitSize = 5;

        public SaltwaterFish(string name, string species, decimal price)
             : base(name, species, price)
        {
            this.Size = InitSize;
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
