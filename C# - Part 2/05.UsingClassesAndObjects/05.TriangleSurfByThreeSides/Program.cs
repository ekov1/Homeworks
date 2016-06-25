using System;

namespace _05.TriangleSurfByThreeSides
{
    class Program
    {
        static void Main()
        {
            double firstSide = double.Parse(Console.ReadLine());
            double secondSide = double.Parse(Console.ReadLine());
            double thirdSide = double.Parse(Console.ReadLine());

            SurfaceOfTriangle(firstSide, secondSide, thirdSide);
        }

        static void SurfaceOfTriangle(double firstSide, double secondSide, double thirdSide)
        {
            double halfP = (firstSide + secondSide + thirdSide) / 2;
            double surface = Math.Sqrt(halfP * (halfP - firstSide) * (halfP - secondSide) * (halfP - thirdSide));

            Console.WriteLine(surface.ToString("0.00"));
        }
    }
}
