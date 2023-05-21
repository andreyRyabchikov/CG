using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG2
{
    public class Triangle
    {
        public Point3D Point1 { get; set; }
        public Point3D Point2 { get; set; }
        public Point3D Point3 { get; set; }
        public Color Color { get; set; }

        public Triangle(Point3D point1, Point3D point2, Point3D point3, Color color)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
            Color = color;
        }

        public Vector3D GetNormal()
        {
            Vector3D v1 = new Vector3D(Point2.X - Point1.X, Point2.Y - Point1.Y, Point2.Z - Point1.Z);
            Vector3D v2 = new Vector3D(Point3.X - Point1.X, Point3.Y - Point1.Y, Point3.Z - Point1.Z);

            return Vector3D.CrossProduct(v1, v2).Normalize();
        }
    }

}
