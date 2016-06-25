using System;

namespace _02.TriangleSurface
{
    class Program
    {
        static void Main()
        {
            double side = double.Parse(Console.ReadLine());
            double alt = double.Parse(Console.ReadLine());
            SurfaceOfTriangle(side, alt);
        }

        static void SurfaceOfTriangle(double side, double alt)
        {
            double surface = (side * alt) / 2;

            Console.WriteLine(surface.ToString("0.00"));
        }
    }
}
