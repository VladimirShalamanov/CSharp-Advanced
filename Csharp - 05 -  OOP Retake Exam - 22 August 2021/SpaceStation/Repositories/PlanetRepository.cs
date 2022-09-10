﻿namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using SpaceStation.Models.Planets.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new HashSet<IPlanet>();
        }
        public int CountExplored = 0;

        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)this.models;

        public void Add(IPlanet model) => this.models.Add(model);

        public bool Remove(IPlanet model) => this.models.Remove(model);

        public IPlanet FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
    }
}
