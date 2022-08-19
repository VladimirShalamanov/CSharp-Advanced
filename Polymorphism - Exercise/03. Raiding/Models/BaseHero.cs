namespace P03.Raiding.Models
{
    public abstract class BaseHero
    {
        public string Name;
        public int Power;

        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public abstract string CastAbility();
    }
}
