namespace SpaceStation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    using Models.Astronauts;
    using Models.Astronauts.Contracts;
    using Models.Planets;

    using Repositories;
    using SpaceStation.Models.Mission;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly AstronautRepository astronauts;
        private readonly PlanetRepository planets;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut ast;
            if (type == "Biologist")
            {
                ast = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                ast = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                ast = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronauts.Add(ast);
            return String.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            if (items.Any())
                foreach (var item in items) planet.Items.Add(item);

            this.planets.Add(planet);
            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            var retireA = this.astronauts.FindByName(astronautName);

            if (retireA == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(retireA);
            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }
        public string ExplorePlanet(string planetName)
        {
            if (!this.astronauts.Models.Where(x => x.Oxygen > 60).Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            var planet = this.planets.FindByName(planetName);

            Mission mission = new Mission();
            mission.Explore(planet, this.astronauts.Models.Where(x => x.Oxygen > 60).ToList());

            var dead = this.astronauts.Models.Where(x => !x.CanBreath).ToList().Count;
            if (!planet.Items.Any())
            {
                this.planets.CountExplored++;
            }
            return String.Format(OutputMessages.PlanetExplored, planetName, dead);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.planets.CountExplored} planets were explored!")
              .AppendLine($"Astronauts info:");

            foreach (IAstronaut a in this.astronauts.Models)
            {
                sb.AppendLine($"Name: {a.Name}")
                  .AppendLine($"Oxygen: {a.Oxygen}")
                  .AppendLine($"Bag items: {(a.Bag.Items.Any() ? string.Join(", ", a.Bag.Items) : "none")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
