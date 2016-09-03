namespace Abstraction.Models
{
    using System;
    using Contracts;

    public abstract class Figure : IFigure
    {
        public Figure()
        {
        }

        public abstract double CalculateSurface();

        public abstract double CalculatePerimeter();

        public override string ToString()
        {
            var output = string.Format(
                "I am a {2}. My perimeter is {0:f2}. My surface is {1:f2}.",
                this.CalculatePerimeter(), 
                this.CalculateSurface(),
                this.GetType().Name);

            return output;
        }
    }
}
