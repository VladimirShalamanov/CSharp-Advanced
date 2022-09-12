namespace Easter.Repositories
{
    using Contracts;
    using Models.Bunnies.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> models;

        public BunnyRepository()
        {
            this.models = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.models.AsReadOnly();

        public void Add(IBunny model) => this.models.Add(model);

        public bool Remove(IBunny model) => this.models.Remove(model);

        public IBunny FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
    }
}
