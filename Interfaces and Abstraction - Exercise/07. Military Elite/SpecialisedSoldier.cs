using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public string Corps { get; private set; }

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }
    }
}
