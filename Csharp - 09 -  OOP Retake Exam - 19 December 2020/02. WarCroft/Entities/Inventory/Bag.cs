namespace WarCroft.Entities.Inventory
{
    using Constants;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WarCroft.Entities.Items;

    public abstract class Bag : IBag
    {
        private int capacity;
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get => this.capacity; set => this.capacity = value; }

        public int Load => this.Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            var itemToGetting = this.items.FirstOrDefault(x => x.GetType().Name == name);
            if (itemToGetting == null)
            {
                throw new ArgumentException(ExceptionMessages.ItemNotFoundInBag, name);
            }

            this.items.Remove(itemToGetting);
            return itemToGetting;
        }
    }
}
