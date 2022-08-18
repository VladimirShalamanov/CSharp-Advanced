namespace P09.ExplicitInterfaces.Models
{
    using Interfaces;
    public class Citizen : IPerson, IResident
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Citizen(string name, string country)
        {
            this.Name = name;
            this.Country = country;
        }

        void IPerson.GetName()
        {
            System.Console.WriteLine(this.Name);
        }
        void IResident.GetName()
        {
            System.Console.WriteLine($"Mr/Ms/Mrs {this.Name}");
        }
    }
}
