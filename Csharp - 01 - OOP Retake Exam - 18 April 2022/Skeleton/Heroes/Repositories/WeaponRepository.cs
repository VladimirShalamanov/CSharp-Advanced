namespace Heroes.Repositories
{
    using Contracts;
    using Models.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models;
        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models
            => (IReadOnlyCollection<IWeapon>)this.models;

        public void Add(IWeapon model)
            => this.models.Add(model);

        public IWeapon FindByName(string name)
            => this.models.FirstOrDefault(h => h.Name == name);

        public bool Remove(IWeapon model)
            => this.models.Remove(model);
    }
}
