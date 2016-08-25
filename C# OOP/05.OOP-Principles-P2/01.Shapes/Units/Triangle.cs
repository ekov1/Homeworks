namespace _01.Shapes.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Triangle : Shape
    {
        public Triangle(double width, double height) : base(width, height)
        {

        }

        public override void CalculateSurface()
        {
            var result = (Height * Width) / 2;
            Console.WriteLine("Area of {0} -> {1}", this.GetType().Name, result);
        }
    }
}
