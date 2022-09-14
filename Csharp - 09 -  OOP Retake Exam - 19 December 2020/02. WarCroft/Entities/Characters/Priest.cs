namespace WarCroft.Entities.Characters
{
    using System;
    using WarCroft.Entities.Inventory;
    using WarCroft.Entities.Characters.Contracts;

    public class Priest : Character, IHealer
    {
        private const double health = 50;
        private const double armor = 25;
        private const double abilityPoints = 40;
        private static IBag CurrBag = new Backpack();

        public Priest(string name)
            : base(name, health, armor, abilityPoints, CurrBag)
        {
        }

        public void Heal(Character character)
        {
            character.Health += this.AbilityPoints;
        }
    }
}
