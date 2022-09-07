namespace Formula1.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Formula1.Models;
    using Formula1.Models.Contracts;
    using Repositories;
    using Utilities;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = pilotRepository.FindByName(fullName);

            if (pilot != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            this.pilotRepository.Add(new Pilot(fullName));
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = this.carRepository.FindByName(model);
            if (car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            this.carRepository.Add(car);
            return String.Format(OutputMessages.SuccessfullyCreateCar, car.GetType().Name, car.Model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            if (race != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            race = new Race(raceName, numberOfLaps);
            this.raceRepository.Add(race);
            return String.Format(OutputMessages.SuccessfullyCreateRace, race.RaceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = this.pilotRepository.FindByName(pilotName);
            if (pilot == null || pilot.CanRace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            IFormulaOneCar car = this.carRepository.FindByName(carModel);
            if (car == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            this.carRepository.Remove(car);
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilot.FullName, car.GetType().Name, car.Model);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = this.pilotRepository.FindByName(pilotFullName);
            IRace race = this.raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            ICollection<IPilot> nameExisting = race.Pilots.Where(x => x.FullName == pilotFullName).ToList();
            if (pilot == null || !pilot.CanRace || nameExisting.Count > 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilot.FullName, race.RaceName);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, race.RaceName));
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, race.RaceName));
            }

            List<IPilot> pilotsS = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

            pilotsS[0].WinRace();
            race.TookPlace = true;

            var sb = new StringBuilder();
            sb.AppendLine(String.Format(OutputMessages.PilotFirstPlace, pilotsS[0].FullName, raceName))
                .AppendLine(String.Format(OutputMessages.PilotSecondPlace, pilotsS[1].FullName, raceName))
                .AppendLine(String.Format(OutputMessages.PilotThirdPlace, pilotsS[2].FullName, raceName));

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            List<IRace> races = this.raceRepository.Models.Where(x => x.TookPlace).ToList();
            var sb = new StringBuilder();
            foreach (var race in races)
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            List<IPilot> list = this.pilotRepository.Models.OrderByDescending(x => x.NumberOfWins).ToList();
            var sb = new StringBuilder();
            foreach (var pilot in list)
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
