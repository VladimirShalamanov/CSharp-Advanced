namespace Easter.Models.Workshops
{
    using Contracts;
    using Models.Bunnies.Contracts;
    using Models.Eggs.Contracts;
    using System.Linq;

    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 &&
                   bunny.Dyes.Where(x => !x.IsFinished()).Count() > 0 &&
                   !egg.IsDone())
            {
                foreach (var dye in bunny.Dyes.Where(x => !x.IsFinished()))
                {
                    egg.GetColored();
                    bunny.Work();
                    dye.Use();
                    break;
                }
            }
        }
    }
}
