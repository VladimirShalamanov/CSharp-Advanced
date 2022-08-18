namespace P09.ExplicitInterfaces.Models.Interfaces
{
    public interface IResident
    {
        string Name { get; }
        string Country { get; }
        void GetName();
    }
}
