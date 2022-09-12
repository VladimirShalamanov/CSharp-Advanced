namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int InitEnergy = 100;

        public HappyBunny(string name)
            : base(name, InitEnergy)
        {
        }
    }
}
