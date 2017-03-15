using System;

namespace Points
{
    public static class PointDistance
    {
        public static double Distance(Point3D first, Point3D second)
        {
            double xPointsDiff = first.X - second.X;
            double yPointsDiff = first.Y - second.Y;
            double zPointsDiff = first.Z - second.Z;

            double distance = Math.Sqrt(xPointsDiff * xPointsDiff + yPointsDiff * yPointsDiff + zPointsDiff * zPointsDiff);

            return distance;
        }   //calculates distance btw. two points
    }
}
