using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05.FootballTeamGenerator
{
    public class Team
    {
        private readonly List<Player> players;
        private string name;

        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public void Add(Player player)
        {
            this.players.Add(player);
        }
        public void Remove(string player)
        {
            Player playerDel = this.players.FirstOrDefault(p => p.Name == player);
            if (playerDel == null)
            {
                throw new InvalidOperationException($"Player {player} is not in {this.Name} team.");
            }
            this.players.Remove(playerDel);
        }
        public int Rating
        {
            get
            {
                if (this.players.Any())
                {
                   return (int)Math.Round(this.players.Average(p => (p.Endurance + p.Sprint + p.Dribble + p.Passing + p.Shooting) / 5.0), 0);
                }
                return 0;
            }
        }
    }
}
