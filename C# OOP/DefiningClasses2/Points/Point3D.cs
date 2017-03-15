using System;

namespace Points
{
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        private static readonly Point3D SystemStart = new Point3D(0, 0, 0); //start of coordinate system

        public static Point3D O
        {
            get
            {
                return Point3D.SystemStart;
            }
        }   //returns start of coord. system

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }   //constructor taking 3 coordinates


        public override string ToString()
        {
            return $"X: {this.X} \r\nY: {this.Y} \r\nZ: {this.Z}";
        }   //ToString override
    }
}
