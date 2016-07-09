namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class IronItem : Item
    {
        public IronItem(string name, Location location = null)
            : base(name, 3, ItemType.Iron, location)
        {
        }
    }
}
