using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CG2
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
         
            InitializeComponent();
            // Создаем экземпляры классов и координируем взаимодействие между ними.
            ParametricSurface surface = new ParametricSurface();
            //углы
            Projection projection = new Projection(35,0);
            Renderer renderer = new Renderer(pictureBox1.CreateGraphics());
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
            List<Triangle> triangles = surface.GenerateSurface(0, 1000, 0, 1000, 175, Color.Yellow);
            double scale = 0.7;
            foreach (Triangle triangle in triangles)
            {


                // Расчет нормалей треугольника
                Vector3D normal = triangle.GetNormal();

                // Расчет векторов направления света
                Vector3D lightDirection1 = new Vector3D(-1, 0, 0); // Направление первого источника света
                Vector3D lightDirection2 = new Vector3D(0, -1, 0); // Направление второго источника света

                // Расчет коэффициентов материала для треугольника
                Color triangleColor = triangle.Color;
                double ambientCoefficient = 0.1; // Коэффициент фонового освещения
                double diffuseCoefficient = 0.7; // Коэффициент рассеянного освещения
                double specularCoefficient = 0.5; // Коэффициент отраженного освещения
                double shininess = 20; // Степень блеска материала

                // Расчет освещения для треугольника
                Color illuminatedColor = LightSource.CalculateIlluminatedColor(triangleColor, normal, lightDirection1, lightDirection2,
                    ambientCoefficient, diffuseCoefficient, specularCoefficient, shininess);

                // Установка цвета треугольника
                triangle.Color = illuminatedColor;
                
                renderer.DrawTriangle(triangle, Graphics.FromImage(pictureBox1.Image), projection, scale);
            }
            pictureBox1.Refresh();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
