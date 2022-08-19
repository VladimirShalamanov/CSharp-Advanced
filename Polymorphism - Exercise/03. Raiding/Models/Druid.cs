namespace P03.Raiding.Models
{
    using System;
    public class Druid : BaseHero
    {
        public Druid(string name)
            : base(name, 80)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
