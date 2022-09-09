namespace Gym.Models.Equipment
{

    public class BoxingGloves : Equipment
    {
        private const double w = 227;
        private const decimal p = 120m;
        public BoxingGloves()
            : base(w, p)
        {
        }
    }
}
