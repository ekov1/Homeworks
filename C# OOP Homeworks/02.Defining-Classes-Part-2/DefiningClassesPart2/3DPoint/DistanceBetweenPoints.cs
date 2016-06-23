namespace _3DPoint
{
    using System;

    public static class DistanceBetweenPoints
    {
        public static double CalcDistance(Point3D firstPoint, Point3D secondPoint) 
        {
            double distance = 0.0;

             distance = Math.Sqrt((firstPoint.XCoordinates - secondPoint.XCoordinates) * (firstPoint.XCoordinates - secondPoint.XCoordinates) +
                (firstPoint.YCoordinates - secondPoint.YCoordinates) * (firstPoint.YCoordinates - secondPoint.YCoordinates) +
                (firstPoint.ZCoordinates - secondPoint.ZCoordinates) * (firstPoint.ZCoordinates - secondPoint.ZCoordinates));

            return distance;
        }

    }
}
