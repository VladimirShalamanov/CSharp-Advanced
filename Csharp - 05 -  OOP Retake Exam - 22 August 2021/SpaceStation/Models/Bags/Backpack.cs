namespace SpaceStation.Models.Bags
{
    using Contracts;
    using System.Collections.Generic;

    public class Backpack : IBag
    {
        private readonly ICollection<string> items;

        public ICollection<string> Items => this.items;

        public Backpack()
        {
            this.items = new List<string>();
        }
    }
}
