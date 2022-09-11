namespace CarRacing.Repositories
{
    using System;
    using Contracts;
    using System.Linq;
    using Models.Racers.Contracts;
    using Utilities.Messages;
    using System.Collections.Generic;

    public class RacerRepository : IRepository<IRacer>
    {
        private readonly ICollection<IRacer> models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => (IReadOnlyCollection<IRacer>) this.models;

        public void Add(IRacer model)
        {
            if (model == null)
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            this.models.Add(model);
        }

        public bool Remove(IRacer model) => this.models.Remove(model);

        public IRacer FindBy(string property) => this.models.FirstOrDefault(x => x.Username == property);
    }
}
