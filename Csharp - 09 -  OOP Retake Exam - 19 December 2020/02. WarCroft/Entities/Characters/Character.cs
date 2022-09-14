using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private IBag bag;

        protected Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }
        public double BaseHealth
        {
            get => this.baseHealth;
            private set => this.baseHealth = value;
        }
        public double Health
        {
            get => this.health;
            set
            {
                this.health = value;
                if (this.health < 0)
                    this.health = 0;
                if (this.health > this.BaseHealth)
                    this.health = this.BaseHealth;
            }
        }
        public double BaseArmor
        {
            get => this.baseArmor;
            private set => this.baseArmor = value;
        }
        public double Armor
        {
            get => this.armor;
            private set
            {
                this.armor = value;
                if (this.armor < 0)
                    this.armor = 0;
                if (this.armor > this.BaseArmor)
                    this.armor = this.BaseArmor;
            }
        }
        public double AbilityPoints
        {
            get => this.abilityPoints;
            private set => this.abilityPoints = value;
        }

        public IBag Bag { get => this.bag; set => this.bag = value; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                double damage = hitPoints;
                if (this.Armor > 0)
                {
                    if (this.Armor - damage > 0)
                        this.Armor -= damage;

                    else if (this.Armor - damage <= 0)
                    {
                        damage -= this.Armor;
                        this.Armor = 0;
                    }
                }
                if (this.Armor == 0 && this.Health > 0 && damage > 0)
                {
                    if (this.Health - damage > 0)
                        this.Health -= damage;

                    else if (this.Health - damage < 0)
                    {
                        this.Health = 0;
                        this.IsAlive = false;
                    }
                }
            }
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}