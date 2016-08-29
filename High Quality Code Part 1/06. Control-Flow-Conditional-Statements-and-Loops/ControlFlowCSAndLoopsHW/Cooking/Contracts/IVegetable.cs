namespace Cooking.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVegetable
    {
        int Calories { get; }

        bool IsRotten { get; }

        bool IsPeeled { get; set; }

        bool IsCut { get; set; }

        bool IsCooked { get; set; }
    }
}
