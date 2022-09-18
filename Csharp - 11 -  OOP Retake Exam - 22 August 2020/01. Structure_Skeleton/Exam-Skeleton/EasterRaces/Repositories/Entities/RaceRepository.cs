namespace EasterRaces.Repositories.Entities
{
    using System.Linq;
    using Contracts;
    using System.Collections.Generic;
    using EasterRaces.Models.Races.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private ICollection<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public void Add(IRace model) => this.models.Add(model);

        public bool Remove(IRace model) => this.models.Remove(model);

        public IRace GetByName(string name)
            => this.models.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IRace> GetAll()
            => (IReadOnlyCollection<IRace>)this.models;
    }
}
