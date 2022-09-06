namespace Heroes.Models.Heroes
{
    using Contracts;
    using System;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        //ctor
        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                this.health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                this.armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => this.weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                this.weapon = value;
            }
        }

        public bool IsAlive
               => this.health > 0;

        public void AddWeapon(IWeapon weapon)
        {
            if (this.Weapon == null)
            {
                this.Weapon = weapon;
            }
        }

        public void TakeDamage(int points)
        {
            int damagePointLeft = points;
            if (this.Armour > 0)
            {
                if (this.Armour - points > 0)
                {
                    damagePointLeft = 0;
                    this.Armour -= points;
                }
                else
                {
                    damagePointLeft -= this.Armour;
                    this.Armour = 0;
                }
            }

            if (damagePointLeft > 0)
            {
                if (this.Health - damagePointLeft >= 0)
                {
                    this.Health -= damagePointLeft;
                }
                else
                {
                    this.Health = 0;
                }
            }
        }
    }
}
