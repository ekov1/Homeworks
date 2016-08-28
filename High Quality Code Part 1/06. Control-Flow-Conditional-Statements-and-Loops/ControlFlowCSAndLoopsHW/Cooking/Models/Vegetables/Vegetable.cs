namespace Cooking.Models.Vegetables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using Globals;

    public class Vegetable : IVegetable
    {
        public Vegetable()
        {
            this.IsCooked = false;
            this.IsPeeled = false;
            this.IsRotten = false;
            this.IsCut = false;
        }

        public bool IsCooked { get; set; }

        public bool IsPeeled { get; set; }

        public bool IsRotten { get; set; }

        public bool IsCut { get; set; }

        public int Calories { get; protected set; }
    }
}
