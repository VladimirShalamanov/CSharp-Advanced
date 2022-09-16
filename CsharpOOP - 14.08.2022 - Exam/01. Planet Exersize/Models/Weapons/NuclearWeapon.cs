namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double InitPrice = 15;

        public NuclearWeapon(int destructionLevel)
             : base(destructionLevel, InitPrice)
        {
        }
    }
}
