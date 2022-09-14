using System;
using System.Collections.Generic;

using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using System.Linq;
using System.Text;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> chara;
        private List<Item> item;

        public WarController()
        {
            this.chara = new List<Character>();
            this.item = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string type = args[0];
            string name = args[1];
            if (type == "Priest")
            {
                this.chara.Add(new Priest(name));
            }
            else if (type == "Warrior")
            {
                this.chara.Add(new Warrior(name));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCharacterType, type);
            }
            return String.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string name = args[0];
            if (name == "FirePotion")
            {
                this.item.Add(new FirePotion());
            }
            else if (name == "HealthPotion")
            {
                this.item.Add(new HealthPotion());
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidItem, name));
            }
            return String.Format(SuccessMessages.AddItemToPool, name);
        }

        public string PickUpItem(string[] args)
        {
            string name = args[0];
            var currChar = this.chara.FirstOrDefault(x => x.Name == name);
            if (currChar == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, name));
            }
            if (!this.item.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            var it = this.item.Last();
            this.item.Remove(it);
            currChar.Bag.AddItem(it);
            return String.Format(SuccessMessages.PickUpItem, name, it.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string charName = args[0];
            string itemName = args[1];
            var currChar = this.chara.FirstOrDefault(x => x.Name == charName);
            if (currChar == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, charName);
            }
            if (!currChar.Bag.Items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (!currChar.Bag.Items.Any(x => x.GetType().Name == itemName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotFoundInBag, itemName));
            }
            
            var it = currChar.Bag.GetItem(itemName);
            currChar.UseItem(it);
            return String.Format(SuccessMessages.UsedItem, charName, it.GetType().Name);
        }

        public string GetStats()
        {
            var sb = new StringBuilder();

            foreach (var c in this.chara.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine($"{c.Name} - HP: {c.Health}/{c.BaseHealth}, AP: {c.Armor}/{c.BaseArmor}, Status: {(c.IsAlive ? "Alive" : "Dead")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            var attacker = this.chara.FirstOrDefault(x => x.Name == attackerName);
            var receiver = this.chara.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (receiver == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }
            if (attacker is Priest)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attackerName));
            }

            Warrior att = attacker as Warrior;
            att.Attack(receiver);

            var sb = new StringBuilder();
            sb.AppendLine($"{attackerName} attacks {receiverName} for {att.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (!receiver.IsAlive) sb.AppendLine($"{receiver.Name} is dead!");

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            var healer = this.chara.FirstOrDefault(x => x.Name == healerName);
            var receiver = this.chara.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
            }
            if (receiver == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healingReceiverName);
            }
            if (healer is Warrior)
            {
                throw new ArgumentException(ExceptionMessages.HealerCannotHeal, healerName);
            }

            Priest hea = healer as Priest;
            hea.Heal(receiver);
            var sb = new StringBuilder();
            sb.AppendLine($"{hea.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

            return sb.ToString().TrimEnd();
        }
    }
}
