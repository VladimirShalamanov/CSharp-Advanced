using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite
{
    public class Spy : Soldier
    {
        public int CodeNumber { get; private set; }
        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            sb.AppendLine($"Code Number: {this.CodeNumber}");
            return sb.ToString().TrimEnd();
        }
    }
}
