namespace P09.ExplicitInterfaces
{
    using P09.ExplicitInterfaces.Models.Interfaces;
    using P09.ExplicitInterfaces.Models;
    using System;
    


    public class StartUp
    {
        static void Main(string[] args)
        {
            string cmd;
            while((cmd = Console.ReadLine()) != "End")
            {
                string[] arr = cmd.Split();
                IPerson person = new Citizen(arr[0], int.Parse(arr[2]));
                IResident resident = new Citizen(arr[0], arr[1]);

                person.GetName();
                resident.GetName();
            }
        }
    }
}
