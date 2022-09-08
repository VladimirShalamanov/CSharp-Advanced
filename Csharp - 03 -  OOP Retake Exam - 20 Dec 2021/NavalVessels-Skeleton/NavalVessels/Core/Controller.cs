namespace NavalVessels.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using NavalVessels.Models;
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private VesselRepository vesselRep;
        private List<ICaptain> capitans;

        public Controller()
        {
            this.vesselRep = new VesselRepository();
            this.capitans = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = this.capitans.FirstOrDefault(x => x.FullName == fullName);
            if (captain != null)
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            captain = new Captain(fullName);
            this.capitans.Add(captain);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, captain.FullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel ves = this.vesselRep.FindByName(name);
            if (ves != null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, ves.GetType().Name, ves.Name);
            }
            if (vesselType == "Submarine")
            {
                ves = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                ves = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }
            this.vesselRep.Add(ves);
            return String.Format(OutputMessages.SuccessfullyCreateVessel, ves.GetType().Name, ves.Name, ves.MainWeaponCaliber, ves.Speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain cap = this.capitans.FirstOrDefault(x => x.FullName == selectedCaptainName);

            if (cap == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            IVessel ves = this.vesselRep.FindByName(selectedVesselName);
            if (ves == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (ves.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, ves.Name);
            }

            ves.Captain = cap;
            cap.Vessels.Add(ves);
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName) 
            => this.capitans.FirstOrDefault(x => x.FullName == captainFullName).Report();

        public string VesselReport(string vesselName)
         => this.vesselRep.FindByName(vesselName).ToString();

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel ves = this.vesselRep.FindByName(vesselName);

            if (ves is Battleship)
            {
                (ves as Battleship).ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, ves.Name);
            }
            else if (ves is Submarine)
            {
                (ves as Submarine).ToggleSubmergeMode();
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, ves.Name);
            }
            return string.Format(OutputMessages.VesselNotFound, vesselName);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel ves = this.vesselRep.FindByName(vesselName);
            if (ves == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            ves.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, ves.Name);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel first = this.vesselRep.FindByName(attackingVesselName);
            IVessel second = this.vesselRep.FindByName(defendingVesselName);

            if (first == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            else if (second == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }
            if (first.ArmorThickness <= 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            else if (second.ArmorThickness <= 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            first.Attack(second);
            first.Captain.IncreaseCombatExperience();
            second.Captain.IncreaseCombatExperience();
            return String.Format(OutputMessages.SuccessfullyAttackVessel, second.Name, first.Name, second.ArmorThickness);
        }
    }
}
