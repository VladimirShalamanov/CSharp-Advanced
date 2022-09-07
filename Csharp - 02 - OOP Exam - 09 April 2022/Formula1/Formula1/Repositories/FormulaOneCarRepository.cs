namespace Formula1.Repositories
{
    using Models.Contracts;

    using System.Linq;

    public class FormulaOneCarRepository : Repository<IFormulaOneCar>
    {
        public override IFormulaOneCar FindByName(string name) => this.Models.FirstOrDefault(m => m.Model == name);
    }
}
