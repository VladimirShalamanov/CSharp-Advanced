namespace PlanetWars.Repositories
{
    using Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void AddItem(IPlanet model) => this.models.Add(model);

        public IPlanet FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);

        public bool RemoveItem(string name)
        {
            var removeIt = this.models.FirstOrDefault(x => x.Name == name);
            if (removeIt != null)
            {
                this.models.Remove(removeIt);
                return true;
            }
            return false;
        }
    }
}
