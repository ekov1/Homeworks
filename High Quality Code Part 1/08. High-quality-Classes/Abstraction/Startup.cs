namespace Abstraction
{
    using System;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var circleRadius = 5.6;
            var circle = new Circle(circleRadius);

            Console.WriteLine(circle);

            var rectWidth = 40.3;
            var rectHeight = 10.1;
            var rectangle = new Rectangle(rectWidth, rectHeight);

            Console.WriteLine(rectangle);
        }
    }
}