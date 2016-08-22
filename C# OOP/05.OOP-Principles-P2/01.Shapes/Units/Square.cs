namespace _01.Shapes.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Square : Shape
    {
        public Square(double width) : base(width, width)
        {

        }

        public override void CalculateSurface()
        {
            var result = Width * Width;
            Console.WriteLine("Area of {0} -> {1}", this.GetType().Name, result);
        }
    }
}
