using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite
{
    public class Mission
    {
        public Mission(string missionName, string state)
        {
            this.MissionName = missionName;
            this.State = state;
        }

        public string MissionName { get; set; }

        public string State { get; set; }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"  Code Name: {this.MissionName} State: {this.State}";
        }
    }
}
