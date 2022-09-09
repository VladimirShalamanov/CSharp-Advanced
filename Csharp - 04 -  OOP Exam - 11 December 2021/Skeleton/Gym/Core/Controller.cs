namespace Gym.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Repositories;
    using Utilities.Messages;
    using Models.Gyms.Contracts;
    using Gym.Models.Gyms;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Equipment;
    using System.Linq;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Athletes;
    using System.Text;

    public class Controller : IController
    {
        private EquipmentRepository equipmentRep;
        private List<IGym> gymList;

        public Controller()
        {
            this.equipmentRep = new EquipmentRepository();
            this.gymList = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            this.gymList.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            this.equipmentRep.Add(equipment);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym g = this.gymList.FirstOrDefault(x => x.Name == gymName);
            IEquipment remEq = this.equipmentRep.FindByType(equipmentType);
            if (remEq == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            g?.AddEquipment(remEq);
            this.equipmentRep.Remove(remEq);
            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym g = this.gymList.FirstOrDefault(x => x.Name == gymName);
            IAthlete ath;

            if (athleteType == "Boxer")
            {
                ath = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                ath = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }


            if (ath is Boxer && g is WeightliftingGym ||
                ath is Weightlifter && g is BoxingGym)
            {
                return OutputMessages.InappropriateGym;
            }

            this.gymList.FirstOrDefault(x => x.Name == gymName).AddAthlete(ath);
            
            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string TrainAthletes(string gymName)
        {
            this.gymList.FirstOrDefault(x => x.Name == gymName).Exercise();
            var g = this.gymList.FirstOrDefault(x => x.Name == gymName);
            return String.Format(OutputMessages.AthleteExercise, g.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            double g = this.gymList.FirstOrDefault(x => x.Name == gymName).EquipmentWeight;
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, g);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var gym in this.gymList)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
