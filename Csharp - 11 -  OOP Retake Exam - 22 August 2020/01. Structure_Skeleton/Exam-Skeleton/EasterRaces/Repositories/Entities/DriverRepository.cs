namespace EasterRaces.Repositories.Entities
{
    using System.Linq;
    using Contracts;
    using System.Collections.Generic;
    using EasterRaces.Models.Drivers.Contracts;

    public class DriverRepository : IRepository<IDriver>
    {
        private ICollection<IDriver> models;

        public DriverRepository()
        {
            this.models = new List<IDriver>();
        }

        public void Add(IDriver model) => this.models.Add(model);

        public bool Remove(IDriver model) => this.models.Remove(model);

        public IDriver GetByName(string name)
            => this.models.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IDriver> GetAll()
            => (IReadOnlyCollection<IDriver>)this.models;
    }
}
