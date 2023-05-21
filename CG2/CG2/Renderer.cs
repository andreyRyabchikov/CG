using System.Drawing;
using System.Windows.Forms;

namespace CG2
{
    public class Renderer
    {
        private Graphics graphics; // Графический контекст окна

        public Renderer(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void DrawTriangle(Triangle triangle, Graphics graphics, Projection projection, double scale)
        {
            // Применяем углы поворота для осей X и Y
            double rotatedX1 = projection.ProjectX(triangle.Point1.X, triangle.Point1.Y, triangle.Point1.Z) * scale;
            double rotatedY1 = projection.ProjectY(triangle.Point1.X, triangle.Point1.Y, triangle.Point1.Z) * scale;
            double rotatedX2 = projection.ProjectX(triangle.Point2.X, triangle.Point2.Y, triangle.Point2.Z) * scale;
            double rotatedY2 = projection.ProjectY(triangle.Point2.X, triangle.Point2.Y, triangle.Point2.Z) * scale;
            double rotatedX3 = projection.ProjectX(triangle.Point3.X, triangle.Point3.Y, triangle.Point3.Z) * scale;
            double rotatedY3 = projection.ProjectY(triangle.Point3.X, triangle.Point3.Y, triangle.Point3.Z) * scale;

            // Преобразуем трехмерные координаты в двумерные экранные координаты
            Point screenPoint1 = new Point((int)rotatedX1, (int)rotatedY1);
            Point screenPoint2 = new Point((int)rotatedX2, (int)rotatedY2);
            Point screenPoint3 = new Point((int)rotatedX3, (int)rotatedY3);

            // Создаем объекты кистей для заливки и обводки треугольника
            Brush fillBrush = new SolidBrush(triangle.Color);
            Pen outlinePen = new Pen(Color.Black);// Черный цвет для обводки треугольника

            // Рисуем треугольник на графическом контексте pictureBox1

            graphics.FillPolygon(fillBrush, new[] { screenPoint1, screenPoint2, screenPoint3 });
            graphics.DrawPolygon(outlinePen, new[] { screenPoint1, screenPoint2, screenPoint3 });


            // Освобождаем ресурсы кистей и пера
            fillBrush.Dispose();
            outlinePen.Dispose();
        }
    }
}