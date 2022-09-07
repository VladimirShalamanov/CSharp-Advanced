namespace Formula1.Repositories
{
    using Models.Contracts;

    using System.Linq;

    public class PilotRepository : Repository<IPilot>
    {
        public override IPilot FindByName(string name) => this.Models.FirstOrDefault(n => n.FullName == name);
    }
}
