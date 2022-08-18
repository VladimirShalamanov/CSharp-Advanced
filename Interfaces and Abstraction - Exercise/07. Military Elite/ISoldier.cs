using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite
{
    public interface ISoldier
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
