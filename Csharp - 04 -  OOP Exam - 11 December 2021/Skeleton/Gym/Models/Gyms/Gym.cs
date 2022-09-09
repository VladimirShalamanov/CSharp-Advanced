namespace Gym.Models.Gyms
{
    using System.Collections.Generic;
    using System;
    using Contracts;
    using Equipment;
    using Equipment.Contracts;
    using Athletes.Contracts;
    using Utilities.Messages;
    using System.Linq;
    using System.Text;

    public abstract class Gym : IGym
    {
        private string name;

        private Gym()
        {
            this.Equipment = new HashSet<IEquipment>();
            this.Athletes = new HashSet<IAthlete>();
        }
        protected Gym(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes { get; }

        public double EquipmentWeight => this.Equipment.Sum(s => s.Weight);

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete) => this.Athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment) => this.Equipment.Add(equipment);

        public void Exercise()
        {
            foreach (IAthlete a in this.Athletes)
                a.Exercise();
        }

        public string GymInfo()
        {
            var s = new StringBuilder();
            s.AppendLine($"{this.Name} is a {this.GetType().Name}:")
                .AppendLine($"Athletes: {(this.Athletes.Any() ? string.Join(", ", this.Athletes.Select(a => a.FullName)) : "No athletes")}")
                .AppendLine($"Equipment total count: {this.Equipment.Count}")
                .AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");
            return s.ToString().TrimEnd();
        }
    }
}
