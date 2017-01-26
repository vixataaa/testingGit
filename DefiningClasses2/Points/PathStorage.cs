using System;
using System.IO;

namespace Points
{
    public static class PathStorage
    {
        public static void SaveToFile(Path path, string file)
        {
            StreamWriter writer = new StreamWriter(file, true); //gets filename (true stands for appeding instead of erasing file first)

            using (writer)
            {
                foreach (var point in path.Points)
                {
                    writer.WriteLine("{0}, {1}, {2}", point.X, point.Y, point.Z);
                }
            }
        }   //writes each point`s X, Y, Z coordinates to a selected file.
        public static Path LoadFromFile(string file)
        {
            Path path = new Path();

            string[] points;

            StreamReader reader = new StreamReader(file);

            using (reader)
            {
                points = reader.ReadToEnd().Split(new string[] { ", ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);    //splits the content of file by lines in the string array
                for (int i = 0; i < points.Length; i += 3)
                {
                    double x = double.Parse(points[i]);
                    double y = double.Parse(points[i + 1]);
                    double z = double.Parse(points[i + 2]);

                    path.AddPoint(new Point3D(x, y, z));
                }
            }

            return path;
        }


    }
}


