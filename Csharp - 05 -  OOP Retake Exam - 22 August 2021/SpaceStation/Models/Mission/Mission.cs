namespace SpaceStation.Models.Mission
{
    using System.Linq;
    using Contracts;
    using System.Collections.Generic;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets.Contracts;

    public class Mission : IMission
    {
        public Mission()
        {
        }

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut ast in astronauts.Where(a => a.CanBreath))
            {
                if (planet.Items.Any())
                {
                    List<string> planetItems = new List<string>();
                    planetItems = planet.Items.ToList();

                    foreach (string item in planetItems)
                    {
                        ast.Breath();
                        ast.Bag.Items.Add(item);
                        planet.Items.Remove(item);
                        if (!planet.Items.Any()) return;
                        if (!ast.CanBreath) break;
                    }
                }
            }
        }
    }
}
