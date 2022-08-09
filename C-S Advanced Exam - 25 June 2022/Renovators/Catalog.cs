using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> renovators { get; set; }
        public IReadOnlyCollection<Renovator> Renovators => renovators;
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new List<Renovator>();
        }

        public int Count
        {
            get => this.renovators.Count;
        }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (this.renovators.Count == this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            this.renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            bool s = false;
            var remove = this.renovators.FirstOrDefault(x => x.Name == name);
            if (remove != null)
            {
                this.renovators.Remove(remove);
                s = true;
                return s;
            }
            return s;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            List<Renovator> remove = this.renovators.FindAll(x => x.Type == type).ToList();
            if (remove.Count > 0)
            {
                foreach (var r in remove)
                {
                    this.renovators.Remove(r);
                }
                return remove.Count;
            }
            return 0;
        }

        public Renovator HireRenovator(string name)
        {
            var hire = this.renovators.FirstOrDefault(x => x.Name == name);
            if (hire != null)
            {
                foreach (var r in this.renovators)
                {
                    if (r == hire)
                    {
                        r.Hired = true;
                    }
                }
                return hire;
            }
            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> hire = this.renovators.FindAll(x => x.Days >= days);
            return hire.ToList();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");
            foreach (var r in renovators.Where(r => r.Hired == false))
            {
                sb.AppendLine(r.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
