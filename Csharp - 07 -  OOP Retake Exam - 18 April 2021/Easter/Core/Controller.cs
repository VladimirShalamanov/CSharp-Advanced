namespace Easter.Core
{
    using System;
    using Contracts;
    using Repositories;
    using Models.Bunnies;
    using Models.Bunnies.Contracts;
    using Utilities.Messages;
    using Easter.Models.Dyes;
    using Easter.Models.Eggs;
    using Easter.Models.Workshops;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private BunnyRepository bunnyRep;
        private EggRepository eggRep;

        public Controller()
        {
            this.bunnyRep = new BunnyRepository();
            this.eggRep = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            this.bunnyRep.Add(bunny);
            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var bunny = this.bunnyRep.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            var dye = new Dye(power);
            bunny.AddDye(dye);
            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);
            this.eggRep.Add(egg);
            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var workshop = new Workshop();

            var bunniesForColoring = this.bunnyRep.Models.Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy).ToList();

            if (bunniesForColoring.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            var egg = this.eggRep.FindByName(eggName);

            foreach (var bunny in bunniesForColoring)
            {
                workshop.Color(egg, bunny);
            }

            var bunnyWithNoEnergy = this.bunnyRep.Models.Where(x => x.Energy == 0).ToList();

            foreach (var bunny in bunnyWithNoEnergy)
            {
                this.bunnyRep.Remove(bunny);
            }

            if (egg.IsDone())
                return String.Format(OutputMessages.EggIsDone, eggName);
            return String.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.eggRep.Models.Where(x => x.IsDone()).Count()} eggs are done!");
            sb.AppendLine($"Bunnies info:");

            foreach (var b in this.bunnyRep.Models)
            {
                sb.AppendLine(b.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
