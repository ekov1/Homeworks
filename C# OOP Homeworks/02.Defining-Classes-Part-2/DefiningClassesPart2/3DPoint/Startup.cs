namespace _3DPoint
{
    using System;
    using System.IO;

    class Startup
    {
        static void Main()
        {
            Point3D firstPoint = new Point3D(45, 3, 12);
            var distance = DistanceBetweenPoints.CalcDistance(firstPoint, Point3D.StartCoordinates);
            Console.WriteLine("The distance between the two points is {0}\n", distance);

            PathStorage.LoadPath();
            Console.WriteLine("Calling sequence of points from a txt file\n" + new string('=', 60));
            foreach (var item in Path.Points)
            {
                Console.WriteLine(item);
            }
        }

    }
}
