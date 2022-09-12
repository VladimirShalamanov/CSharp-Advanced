namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int InitEnergy = 50;

        public SleepyBunny(string name)
            : base(name, InitEnergy)
        {
        }

        public override void Work()
        {
            this.Energy -= 15;
        }
    }
}
