namespace WarCroft.Entities.Characters
{
    using System;
    using WarCroft.Constants;
    using WarCroft.Entities.Inventory;
    using WarCroft.Entities.Characters.Contracts;

    public class Warrior : Character, IAttacker
    {
        private const double health = 100;
        private const double armor = 50;
        private const double abilityPoints = 40;
        private static IBag CurrBag = new Satchel();

        public Warrior(string name)
            : base(name, health, armor, abilityPoints, CurrBag) 
        {
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this.Name == character.Name)
                {
                    throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
                }

                character.TakeDamage(this.AbilityPoints);
            }
            else if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}
