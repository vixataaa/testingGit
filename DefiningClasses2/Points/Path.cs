using System;
using System.Collections.Generic;

namespace Points
{
    public class Path
    {
        public List<Point3D> Points { private set; get; }

        public Path()
        {
            this.Points = new List<Point3D>();
        }   //constructor, no parameters

        public Path(List<Point3D> points)
        {
            this.Points = points;
        }   //constructor with parameters, creates new instance from a given list of points

        public void AddPoint(Point3D point)
        {
            this.Points.Add(point);
        }   //add point to the path
        public void RemovePoint(Point3D point)
        {
            this.Points.Remove(point);
        }   //removes point from the path

        public override string ToString()
        {
            string result = "";

            foreach (var point in Points)
            {
                result += String.Format("({0}, {1}, {2})", point.X, point.Y, point.Z);
                result += "\r\n";
            }

            return result;
        }   //each point on a new line;
    }
}
