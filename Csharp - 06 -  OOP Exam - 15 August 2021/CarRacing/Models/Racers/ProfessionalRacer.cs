namespace CarRacing.Models.Racers
{
    using Models.Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const string RacingBehaviorRacer = "strict";
        private const int DrivingExperienceRacer = 30;

        public ProfessionalRacer(string username, ICar car)
            : base(username, RacingBehaviorRacer, DrivingExperienceRacer, car)
        {
        }

        public override void Race()
        {
            this.Car.Drive();
            this.DrivingExperience += 10;
        }
    }
}
