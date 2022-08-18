using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public List<Repair> Repairs { get; }

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<Repair>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");
            foreach (var r in this.Repairs)
            {
                sb.AppendLine(r.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
