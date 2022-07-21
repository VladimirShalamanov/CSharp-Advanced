using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public List<Ski> data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public SkiRental(string name, int capacity)
        {
            data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public void Add(Ski ski)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool exists = false;
            var remove = this.data.FirstOrDefault(m => m.Manufacturer == manufacturer && m.Model == model);
            if (remove != null)
            {
                this.data.Remove(remove);
                return exists = true;
            }
            return exists;
        }

        public Ski GetNewestSki()
        {
            var newest = this.data.FirstOrDefault(s => s.Year == this.data.Max(y => y.Year));
            if (newest == null) return null;
            return newest;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            var ski = this.data.FirstOrDefault(m => m.Manufacturer == manufacturer && m.Model == model);
            if (ski == null) return null;
            return ski;
        }

        public int Count
        {
            get => this.data.Count;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var s in data) sb.AppendLine(s.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
