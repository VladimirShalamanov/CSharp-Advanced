namespace Heroes.Models.Map
{
    using global::Heroes.Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Map : IMap
    {
        private readonly ICollection<IHero> knights;
        private readonly ICollection<IHero> barbarians;

        public Map()
        {
            this.barbarians = new List<IHero>();
            this.knights = new List<IHero>();
        }

        public string Fight(ICollection<IHero> players)
        {
            DeployingSoldiers(players);

            while (true)
            {
                Attack(this.knights, this.barbarians);
                if (this.barbarians.All(x => x.IsAlive == false))
                {
                    return $"The knights took {this.knights.Count(x => x.IsAlive == false)} casualties but won the battle.";
                }

                Attack(this.barbarians, this.knights);
                if (this.knights.All(x => x.IsAlive == false))
                {
                    return $"The barbarians took {this.barbarians.Count(x => x.IsAlive == false)} casualties but won the battle.";
                }
            }
        }

        private void DeployingSoldiers(ICollection<IHero> players)
        {
            foreach (var palyer in players)
            {
                if (palyer.GetType().Name == "Knight")
                {
                    this.knights.Add(palyer);
                }
                else if (palyer.GetType().Name == "Barbarian")
                {
                    this.barbarians.Add(palyer);
                }
            }
        }

        private void Attack(
            ICollection<IHero> attackers,
            ICollection<IHero> receivers)
        {
            foreach (var attacker in attackers.Where(x => x.IsAlive))
            {
                foreach (var receiver in receivers.Where(x => x.IsAlive))
                {
                    receiver.TakeDamage(attacker.Weapon.DoDamage());
                }
            }
        }
    }
}
