namespace PlanetWars.Repositories
{
    using Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;

        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.models.AsReadOnly();

        public void AddItem(IMilitaryUnit model) => this.models.Add(model);

        public IMilitaryUnit FindByName(string name) => this.models.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            var removeIt = this.models.FirstOrDefault(x => x.GetType().Name == name);
            if (removeIt != null)
            {
                this.models.Remove(removeIt);
                return true;
            }
            return false;
        }
    }
}
