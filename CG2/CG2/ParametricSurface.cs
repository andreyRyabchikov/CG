using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG2
{
    public class ParametricSurface
    {
        public double Function(double x, double y)
        {


            return x * x - 2 * y * y;

        }

        public List<Triangle> GenerateSurface(double startX, double endX, double startY, double endY, int density, Color color)
        {
            List<Triangle> triangles = new List<Triangle>();
            double stepX = (endX - startX) / density;
            double stepY = (endY - startY) / density;

            for (int i = 0; i < density; i++)
            {
                for (int j = 0; j < density; j++)
                {
                    double x1 = startX + i * stepX;
                    double x2 = startX + (i + 1) * stepX;
                    double y1 = startY + j * stepY;
                    double y2 = startY + (j + 1) * stepY;

                    double z1 = Function(x1, y1);
                    double z2 = Function(x2, y1);
                    double z3 = Function(x1, y2);
                    double z4 = Function(x2, y2);

                    Point3D point1 = new Point3D(x1, y1, z1);
                    Point3D point2 = new Point3D(x2, y1, z2);
                    Point3D point3 = new Point3D(x1, y2, z3);
                    Point3D point4 = new Point3D(x2, y2, z4);

                    // Проверяем, что все вершины треугольника находятся выше оси OX
                    if (z1 >= 0 && z2 >= 0 && z3 >= 0)
                    {
                        Triangle triangle1 = new Triangle(point1, point2, point3, color);
                        triangles.Add(triangle1);
                    }

                    // Проверяем, что все вершины треугольника находятся выше оси OX
                    if (z3 >= 0 && z2 >= 0 && z4 >= 0)
                    {
                        Triangle triangle2 = new Triangle(point3, point2, point4, color);
                        triangles.Add(triangle2);
                    }
                }
            }

            return triangles;
        }
    }

    }
