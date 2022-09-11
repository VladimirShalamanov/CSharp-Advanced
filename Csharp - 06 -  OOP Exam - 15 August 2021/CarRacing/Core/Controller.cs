namespace CarRacing.Core
{
    using Models.Maps;
    using Models.Maps.Contracts;
    using Repositories;
    using Contracts;
    using CarRacing.Models.Cars.Contracts;
    using System;
    using CarRacing.Utilities.Messages;
    using CarRacing.Models.Cars;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Models.Racers;
    using System.Text;
    using System.Linq;

    public class Controller : IController
    {
        private readonly CarRepository cars;
        private readonly RacerRepository racers;
        private readonly IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            this.cars.Add(car);
            return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = this.cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer;
            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            this.racers.Add(racer);
            return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);
            if (racerOne == null)
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            if (racerTwo == null)
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var r in this.racers.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(n => n.Username))
            {
                sb.AppendLine($"{r.GetType().Name}: {r.Username}")
                    .AppendLine($"--Driving behavior: {r.RacingBehavior}")
                    .AppendLine($"--Driving experience: {r.DrivingExperience}")
                    .AppendLine($"--Car: {r.Car.Make} {r.Car.Model} ({r.Car.VIN})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
