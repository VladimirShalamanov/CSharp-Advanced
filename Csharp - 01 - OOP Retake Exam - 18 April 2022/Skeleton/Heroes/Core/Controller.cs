namespace Heroes.Core
{
    using Heroes.Core.Contracts;
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Models.Map;
    using Heroes.Models.Weapons;
    using Heroes.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly HeroRepository heroes;
        private readonly WeaponRepository weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (!this.heroes.Models.Any(h => h.Name == heroName))
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (!this.weapons.Models.Any(w => w.Name == weaponName))
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            var hero = this.heroes.Models.First(h => h.Name == heroName);
            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            var weapon = this.weapons.Models.First(w => w.Name == weaponName);
            this.weapons.Remove(weapon);
            hero.AddWeapon(weapon);
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.Models.Any(h => h.Name == name))
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            IHero hero;
            var message = string.Empty;

            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
                message = $"Successfully added Sir {name} to the collection.";
            }
            else if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
                message = $"Successfully added Barbarian {name} to the collection.";
            }
            else
            {
                throw new InvalidOperationException($"Invalid hero type.");
            }

            this.heroes.Add(hero);
            return message;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.weapons.Models.Any(w => w.Name == name))
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            IWeapon weapon;
            if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }
            else if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else
            {
                throw new InvalidOperationException($"Invalid weapon type.");
            }
            this.weapons.Add(weapon);
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            var sb = new StringBuilder();
            foreach (var hero in this.heroes.Models.OrderBy(h => h.GetType().Name)
                                                   .ThenByDescending(h => h.Health)
                                                   .ThenBy(h => h.Name))
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                if (hero.Weapon != null)
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
                else
                {
                    sb.AppendLine($"--Weapon: Unarmed");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            var map = new Map();
            return map.Fight(
                this.heroes
                .Models
                .Select(x => x)
                .Where(x => x.IsAlive && x.Weapon != null)
                .ToList());
        }
    }
}
