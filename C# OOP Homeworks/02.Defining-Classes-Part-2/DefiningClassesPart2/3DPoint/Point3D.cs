namespace _3DPoint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public struct Point3D
    {
        private static readonly Point3D pointO = new Point3D(0, 0, 0);

        public Point3D(double x, double y, double z)
        {
            this.XCoordinates = x;
            this.YCoordinates = y;
            this.ZCoordinates = z;
        }

        public double XCoordinates { get; set; }
        public double YCoordinates { get; set; }
        public double ZCoordinates { get; set; }

        public static Point3D StartCoordinates
        {
            get
            {
                return pointO;
            }
        }

        public override string ToString()
        {
            return $"({this.XCoordinates}, {this.YCoordinates}, {this.ZCoordinates})";
        }

       
    }
}
