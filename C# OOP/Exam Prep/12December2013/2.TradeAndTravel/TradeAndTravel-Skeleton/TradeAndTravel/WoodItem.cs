namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WoodItem : Item
    {
        public WoodItem(string name, Location location = null)
            : base(name, 2, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop")
            {
                while (this.Value > 0)
                {
                    this.Value--;
                }
            }
        }

    }
}
