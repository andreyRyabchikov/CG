using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG2
{
    public class Projection
    {
        private double rotationAngleX; // Угол поворота по оси X
        private double rotationAngleY; // Угол поворота по оси Y

        public Projection(double rotationAngleX, double rotationAngleY)
        {
            this.rotationAngleX = rotationAngleX;
            this.rotationAngleY = rotationAngleY;
        }

        public double ProjectX(double x, double y, double z)
        {
            // Применяем углы поворота для оси X
            double rotatedX = x;
            double rotatedY = y * Math.Cos(rotationAngleX) - z * Math.Sin(rotationAngleX);
            double rotatedZ = y * Math.Sin(rotationAngleX) + z * Math.Cos(rotationAngleX);

            // Возвращаем x-координату для параллельной проекции
            return rotatedX;
        }

        public double ProjectY(double x, double y, double z)
        {
            // Применяем углы поворота для оси Y
            double rotatedX = x * Math.Cos(rotationAngleY) + z * Math.Sin(rotationAngleY);
            double rotatedY = y;
            double rotatedZ = -x * Math.Sin(rotationAngleY) + z * Math.Cos(rotationAngleY);

            // Возвращаем y-координату для параллельной проекции
            return rotatedY;
        }
    }
}
