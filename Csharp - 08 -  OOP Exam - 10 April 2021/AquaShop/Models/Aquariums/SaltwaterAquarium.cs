﻿namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int InitCapacity = 25;

        public SaltwaterAquarium(string name)
             : base(name, InitCapacity)
        {
        }
    }
}
