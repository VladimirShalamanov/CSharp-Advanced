namespace AquaShop.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Repositories;
    using Models.Aquariums;
    using Models.Aquariums.Contracts;
    using Utilities.Messages;
    using AquaShop.Models.Decorations;
    using System.Linq;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish;
    using AquaShop.Models.Fish.Contracts;
    using System.Text;

    public class Controller : IController
    {
        private DecorationRepository decorationRep;
        private HashSet<IAquarium> aquarium;

        public Controller()
        {
            this.decorationRep = new DecorationRepository();
            this.aquarium = new HashSet<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                this.aquarium.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                this.aquarium.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                this.decorationRep.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                this.decorationRep.Add(new Plant());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquarium.FirstOrDefault(x => x.Name == aquariumName);
            IDecoration decoration = this.decorationRep.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium?.AddDecoration(decoration);
            this.decorationRep.Remove(decoration);
            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium a = this.aquarium.FirstOrDefault(x => x.Name == aquariumName);

            IFish f;
            if (fishType == "FreshwaterFish")
            {
                f = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                f = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if (a is FreshwaterAquarium && f is SaltwaterFish ||
                a is SaltwaterAquarium && f is FreshwaterFish)
            {
                return OutputMessages.UnsuitableWater;
            }

            a.AddFish(f);
            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string FeedFish(string aquariumName)
        {
            this.aquarium.FirstOrDefault(x => x.Name == aquariumName).Feed();
            IAquarium a = this.aquarium.FirstOrDefault(x => x.Name == aquariumName);
            return String.Format(OutputMessages.FishFed, a.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            decimal sum = this.aquarium.FirstOrDefault(x => x.Name == aquariumName).Fish.Sum(x => x.Price)
                        + this.aquarium.FirstOrDefault(x => x.Name == aquariumName).Decorations.Sum(x => x.Price);
            return String.Format(OutputMessages.AquariumValue, aquariumName, sum);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var a in this.aquarium)
            {
                sb.AppendLine(a.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
