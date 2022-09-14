namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int InitCap = 100;

        public Backpack()
             : base(InitCap)
        {
        }
    }
}
