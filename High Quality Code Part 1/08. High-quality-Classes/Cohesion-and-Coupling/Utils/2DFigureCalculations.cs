namespace CohesionAndCoupling.Utils
{
    using System;
    using Contracts;

    public class _2DFigureCalculations
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double powerXDistance = (x2 - x1) * (x2 - x1);
            double powerYDistance = (y2 - y1) * (y2 - y1);

            double distance = Math.Sqrt(powerXDistance + powerYDistance);
            return distance;
        }

        public static double CalcDiagonal2D(IFigure figure)
        {
            double distance = CalcDistance2D(0, 0, figure.Width, figure.Height);
            return distance;
        }
    }
}
