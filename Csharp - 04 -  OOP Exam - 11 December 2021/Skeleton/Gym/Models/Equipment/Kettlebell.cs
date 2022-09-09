namespace Gym.Models.Equipment
{

    public class Kettlebell : Equipment
    {
        private const double w = 10000;
        private const decimal p = 80m;
        public Kettlebell()
            : base(w, p)
        {
        }
    }
}
