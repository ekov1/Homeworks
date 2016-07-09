﻿namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Weapon : Item
    {
        public Weapon(string name, Location location = null)
            : base(name, 10, ItemType.Weapon, location)
        {
        }
    }
}
