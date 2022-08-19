namespace P03.Raiding.Models
{
    using System;
    public class Paladin : BaseHero
    {
        public Paladin(string name)
            : base(name, 100)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
