namespace P03.Raiding.Models
{
    using System;
    public class Warrior : BaseHero
    {
        public Warrior(string name)
            : base(name, 100)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
