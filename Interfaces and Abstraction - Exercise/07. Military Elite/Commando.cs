using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public List<Mission> Missions { get; }

        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");
            foreach (var m in this.Missions)
            {
                sb.AppendLine(m.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
