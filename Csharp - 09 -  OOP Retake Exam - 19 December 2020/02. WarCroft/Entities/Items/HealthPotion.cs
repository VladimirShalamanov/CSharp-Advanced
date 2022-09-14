namespace WarCroft.Entities.Items
{
    using System;
    using WarCroft.Constants;
    using WarCroft.Entities.Characters.Contracts;

    public class HealthPotion : Item
    {
        private const int InitWeight = 5;

        public HealthPotion()
             : base(InitWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            character.Health += 20;
        }
    }
}
