namespace P04.WildFarm.Models.Animal
{
    using P04.WildFarm.Interfaces;
    using P04.WildFarm.Models.Food;

    public abstract class Feline : Mammal, IFeline
    {
        public string Breed { get; private set; }

        protected Feline(string name, double weight, string livingRegiom, string breed)
            : base(name, weight, livingRegiom)
        {
            this.Breed = breed;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {this.Breed}, {base.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
