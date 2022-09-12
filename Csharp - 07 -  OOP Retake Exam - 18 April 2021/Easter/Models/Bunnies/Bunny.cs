namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Dyes.Contracts;
    using Utilities.Messages;

    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private ICollection<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.dyes = new List<IDye>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException(ExceptionMessages.InvalidBunnyName);
                }
                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set
            {
                this.energy = value;
                if (this.energy < 0)
                    this.energy = 0;
            }
        }

        public ICollection<IDye> Dyes => this.dyes;

        public virtual void Work()
        {
            this.Energy -= 10;
        }

        public void AddDye(IDye dye) => this.Dyes.Add(dye);

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Energy: {this.Energy}");
            sb.AppendLine($"Dyes: {this.Dyes.Where(x => !x.IsFinished()).Count()} not finished");

            return sb.ToString().TrimEnd();
        }
    }
}
