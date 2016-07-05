namespace _3DPoint
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Path
    {
        private static List<Point3D> points;

        static Path()
        {
            points = new List<Point3D>();
        }

        public static List<Point3D> Points
        {
            get { return points; }
        }

        public static void AddPoint(Point3D point)
        {
            points.Add(point);
        }

        public static void RemovePoint(Point3D point)
        {
            points.Remove(point);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var point in Points)
            {
                builder.AppendLine(point.ToString());
            }

            return base.ToString();
        }
    }
}
