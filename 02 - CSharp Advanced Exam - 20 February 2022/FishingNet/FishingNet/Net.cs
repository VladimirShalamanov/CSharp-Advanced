using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> fish { get; set; }
        public string Material { get; set; }
        public int Capacity { get; set; }

        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.fish = new List<Fish>();
        }

        public int Count => this.fish.Count;
        public IReadOnlyCollection<Fish> Fish => (IReadOnlyCollection<Fish>)this.fish;

        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || string.IsNullOrEmpty(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            if (Fish.Count + 1 > Capacity) return "Fishing net is full.";
            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            var fish = this.fish.FirstOrDefault(e => e.Weight == weight);
            if (fish != null)
            {
                return this.fish.Remove(fish);
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            Fish fish = Fish.Where(f => f.FishType == fishType).First();
            return fish;
        }

        public Fish GetBiggestFish()
        {
            var longestFish = this.fish.Max(e => e.Length);
            var fish = this.fish.FirstOrDefault(e => e.Length == longestFish);
            return fish;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");
            foreach (var f in Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(f.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
