using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite
{
    public interface ICommando
    {
         public List<Mission> Missions { get; }
    }
}
