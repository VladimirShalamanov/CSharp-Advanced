namespace P04.WildFarm.Models.Animal
{
    using P04.WildFarm.Interfaces;
    using P04.WildFarm.Models.Food;

    public abstract class Mammal : Animal, IMammal
    {
        public string LivingRegion { get; private set; }

        protected Mammal(string name, double weight, string livingRegiom) : base(name, weight)
        {
            this.LivingRegion = livingRegiom;
        }

    }
}
