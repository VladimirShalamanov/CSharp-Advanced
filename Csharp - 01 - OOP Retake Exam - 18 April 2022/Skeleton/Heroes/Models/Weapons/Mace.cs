namespace Heroes.Models.Weapons
{
    using Contracts;

    public class Mace : Weapon, IWeapon
    {
        private const int damage = 25;
        public Mace(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (this.Durability == 0)
            {
                return 0;
            }

            this.Durability--;
            return damage;
        }
    }
}
