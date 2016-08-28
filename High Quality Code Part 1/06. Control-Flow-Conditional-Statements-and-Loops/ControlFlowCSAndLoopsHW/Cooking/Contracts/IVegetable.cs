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

        bool IsPeeled { get; }

        bool IsCut { get; }

        bool IsCooked { get; }
    }
}
