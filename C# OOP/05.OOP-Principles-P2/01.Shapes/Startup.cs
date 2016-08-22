namespace _01.Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Units;
    class Startup
    {
        static void Main()
        {
            var shapes = new List<Shape>
            {
                new Rectangle(3.5, 6.3),
                new Square(2.2),
                new Triangle(8, 5.9)
            };

            foreach (var shape in shapes)
            {
                shape.CalculateSurface();
            }
        }
    }
}
