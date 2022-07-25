using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Guild(string name, int capacity)
        {
            roster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }

        public void AddPlayer(Player player)
        {
            if (roster.Count + 1 <= this.Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {

            var removes = roster.FirstOrDefault(p => p.Name == name);
            if (removes == null) return false;
            roster.Remove(removes);
            return true;
        }

        public void PromotePlayer(string name)
        {
            var player = roster.FirstOrDefault(p => p.Name == name);
            if (player != null)
            {
                if (player.Rank != "Member")
                {
                    player.Rank = "Member";
                }
            }
        }
        public void DemotePlayer(string name)
        {
            var player = roster.FirstOrDefault(p => p.Name == name);
            if (player != null)
            {
                if (player.Rank != "Trial")
                {
                    player.Rank = "Trial";
                }
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var players = roster.FindAll(p => p.Class == @class);
            roster.RemoveAll(p => p.Class == @class);
            Player[] player = players.ToArray();
            return player;
        }

        public int Count
        {
            get => this.roster.Count();
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var p in roster) sb.AppendLine(p.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
