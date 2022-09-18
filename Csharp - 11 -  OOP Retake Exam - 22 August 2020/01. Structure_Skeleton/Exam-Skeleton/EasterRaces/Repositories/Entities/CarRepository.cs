namespace EasterRaces.Repositories.Entities
{
    using System.Linq;
    using Contracts;
    using System.Collections.Generic;
    using EasterRaces.Models.Cars.Contracts;

    public class CarRepository : IRepository<ICar>
    {
        private ICollection<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public void Add(ICar model) => this.models.Add(model);

        public bool Remove(ICar model) => this.models.Remove(model);

        public ICar GetByName(string name)
            => this.models.FirstOrDefault(x => x.Model == name);

        public IReadOnlyCollection<ICar> GetAll()
            => (IReadOnlyCollection<ICar>)this.models;
    }
}
