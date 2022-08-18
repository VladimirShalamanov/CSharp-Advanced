using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public List<Private> Privates { get; private set; }

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<Private>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine("Privates:");
            foreach (var p in this.Privates)
            {
                sb.AppendLine($"  {p.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
