namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;
        private readonly ICollection<string> items;

        public ICollection<string> Items => this.items;

        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }
    }
}
