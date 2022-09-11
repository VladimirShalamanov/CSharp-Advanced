namespace CarRacing.Models.Racers
{
    using Models.Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const string RacingBehaviorRacer = "aggressive";
        private const int DrivingExperienceRacer = 10;

        public StreetRacer(string username, ICar car)
            : base(username, RacingBehaviorRacer, DrivingExperienceRacer, car)
        {
        }

        public override void Race()
        {
            this.Car.Drive();
            this.DrivingExperience += 5;
        }
    }
}
