namespace Easter.Repositories
{
    using Contracts;
    using Models.Eggs.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> models;

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => this.models.AsReadOnly();

        public void Add(IEgg model) => this.models.Add(model);

        public bool Remove(IEgg model) => this.models.Remove(model);

        public IEgg FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
    }
}
