namespace CohesionAndCoupling.Models
{
    using System;
    using Contracts;

    public class Figure3D : Figure, I3DFigure
    {
        private double depth;

        public Figure3D(double width, double height, double depth)
            : base(width, height)
        {
            this.Depth = depth;
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Depth or 3D figure cannot be zero or a negative number!");
                }

                this.depth = value;
            }
        }
    }
}
