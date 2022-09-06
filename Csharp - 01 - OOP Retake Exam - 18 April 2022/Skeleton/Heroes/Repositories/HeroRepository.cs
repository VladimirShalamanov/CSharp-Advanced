namespace Heroes.Repositories
{
    using Contracts;
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> models;
        public HeroRepository()
        {
            this.models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models
            => (IReadOnlyCollection<IHero>)this.models;

        public void Add(IHero model)
            => this.models.Add(model);

        public IHero FindByName(string name)
            => this.models.FirstOrDefault(h => h.Name == name);

        public bool Remove(IHero model)
            => this.models.Remove(model);
    }
}
