namespace CohesionAndCoupling.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface I3DFigure : IFigure
    {
        double Depth { get; set; }
    }
}
