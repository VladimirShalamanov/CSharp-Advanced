namespace WarCroft.Entities.Items
{
    using System;
    using WarCroft.Constants;
    using WarCroft.Entities.Characters.Contracts;

    public class FirePotion : Item
    {
        private const int InitWeight = 5;

        public FirePotion()
             : base(InitWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            if (character.Health - 20 < 0)
            {
                character.Health = 0;
                character.IsAlive = false;
            }
            else
                character.Health -= 20;
        }
    }
}
