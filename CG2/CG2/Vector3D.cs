using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG2
{
    public class Vector3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double Magnitude()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vector3D Normalize()
        {
            double magnitude = Magnitude();
            return new Vector3D(X / magnitude, Y / magnitude, Z / magnitude);
        }

        public static Vector3D CrossProduct(Vector3D v1, Vector3D v2)
        {
            double x = v1.Y * v2.Z - v1.Z * v2.Y;
            double y = v1.Z * v2.X - v1.X * v2.Z;
            double z = v1.X * v2.Y - v1.Y * v2.X;

            return new Vector3D(x, y, z);
        }

        public static double DotProduct(Vector3D v1, Vector3D v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }
        public static Vector3D operator *(double scalar, Vector3D vector)
        {
            double x = scalar * vector.X;
            double y = scalar * vector.Y;
            double z = scalar * vector.Z;

            return new Vector3D(x, y, z);
        }

        public static Vector3D operator *(Vector3D vector, double scalar)
        {
            return scalar * vector;
        }

        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            double x = vector1.X - vector2.X;
            double y = vector1.Y - vector2.Y;
            double z = vector1.Z - vector2.Z;

            return new Vector3D(x, y, z);
        }
    }
}
