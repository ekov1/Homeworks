using System;

namespace _06.SidesAndAngle
{
    class Program
    {
        static void Main()
        {
            double firstSide = double.Parse(Console.ReadLine());
            double secondSide = double.Parse(Console.ReadLine());
            double angle = double.Parse(Console.ReadLine());
            TriangleSurface(firstSide, secondSide, angle);
        }

        static void TriangleSurface(double firstSide, double secondSide, double angle)
        {
            double radians = (angle * Math.PI) / 180;
            double surface = (firstSide * secondSide * Math.Sin(radians)) / 2;
            Console.WriteLine(surface.ToString("0.00"));
        }
    }
}
