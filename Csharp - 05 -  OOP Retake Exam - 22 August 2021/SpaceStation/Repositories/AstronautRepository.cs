﻿namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using SpaceStation.Models.Astronauts.Contracts;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly ICollection<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new HashSet<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => (IReadOnlyCollection<IAstronaut>)this.models;

        public void Add(IAstronaut model) => this.models.Add(model);

        public bool Remove(IAstronaut model) => this.models.Remove(model);

        public IAstronaut FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
    }
}
