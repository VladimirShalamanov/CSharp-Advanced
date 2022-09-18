namespace EasterRaces.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Cars.Entities;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Drivers.Entities;
    using EasterRaces.Models.Races.Entities;
    using EasterRaces.Repositories.Entities;
    using Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverRepository;
        private CarRepository carRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreateDriver(string driverName)
        {
            var dr = this.driverRepository.GetByName(driverName);
            if (dr != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));
            }
            var newDr = new Driver(driverName);
            this.driverRepository.Add(newDr);

            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (this.carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
            }
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.carRepository.Add(car);
            string ty = car is MuscleCar ? "MuscleCar" : "SportsCar";
            return String.Format(OutputMessages.CarCreated, ty, model);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var dr = this.driverRepository.GetByName(driverName);
            var car = this.carRepository.GetByName(carModel);

            if (dr == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (car == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }
            dr.AddCar(car);
            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.raceRepository.GetByName(raceName);
            var dr = this.driverRepository.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (dr == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            
            race.AddDriver(dr);
            return String.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateRace(string name, int laps)
        {
            var race = this.raceRepository.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }
            var newRace = new Race(name, laps);
            this.raceRepository.Add(newRace);

            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            List<IDriver> sortDr = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).ToList();
            this.raceRepository.Remove(race);

            sortDr[0].WinRace();

            var sb = new StringBuilder();
            sb.AppendLine(String.Format(OutputMessages.DriverFirstPosition, sortDr[0].Name, raceName));
            sb.AppendLine(String.Format(OutputMessages.DriverSecondPosition, sortDr[1].Name, raceName));
            sb.AppendLine(String.Format(OutputMessages.DriverThirdPosition, sortDr[2].Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
