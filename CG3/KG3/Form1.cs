using System;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;
using System.Drawing;

namespace KG3
{
    public partial class Form1 : Form
    {
        private double _Radius = 5; // Радиус сферы
        private int _Slices = 5; // Количество разбиений сферы
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализация Glut
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            // Очистка окна
            Gl.glClearColor(0, 0, 0, 1); // Черный фон
            // Установка порта вывода в соответствии с размерами элемента 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            // Настройка параллельной проекции
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            const double W = 10;
            double H = W * AnT.Height / AnT.Width;
            Gl.glOrtho(-W, W, -H, H, -200, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // Настройка параметров OpenGL для визуализации
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glEnable(Gl.GL_LIGHTING);

            Gl.glEnable(Gl.GL_LIGHT0);
        }

        private void Render(double x, double y)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();
            Gl.glColor3f(1, 1, 1); // Цвет фигуры - белый

            Gl.glPushMatrix();
            Gl.glTranslated(0, -1, -6);
            Gl.glRotated((x - AnT.Height) * 180 / AnT.Height, 0, 1, 0);
            Gl.glRotated((y - AnT.Width) * 180 / AnT.Width, 1, 0, 0);
            Glut.glutSolidSphere(_Radius, _Slices, _Slices); // Рисование сферы с заданными параметрами
            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.Index + 1 != dataGridView1.Rows.Count)
                    {
                        Gl.glEnable(Gl.GL_LIGHT0 + r.Index);
                        float[] pos =
                        {
                            (float)Convert.ToDecimal(r.Cells[0].Value),
                            (float)Convert.ToDecimal(r.Cells[1].Value),
                            (float)Convert.ToDecimal(r.Cells[2].Value), 3
                        };
                        Gl.glLightfv(Gl.GL_LIGHT0 + r.Index, Gl.GL_POSITION, pos);
                        float[] color =
                        {
                            ((Color)r.Cells[3].Value).R / (float)255,
                            ((Color)r.Cells[3].Value).G / (float)255,
                            ((Color)r.Cells[3].Value).B / (float)255, 1
                        };
                        Gl.glLightfv(Gl.GL_LIGHT0 + r.Index, Gl.GL_DIFFUSE, color);
                        //float[] dir = { (float)Convert.ToDecimal(r.Cells[3].Value), (float)Convert.ToDecimal(r.Cells[4].Value), (float)Convert.ToDecimal(r.Cells[5].Value) };
                        //Gl.glLightfv(Gl.GL_LIGHT0 + r.Index, Gl.GL_SPOT_DIRECTION, dir);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка входных данных!");
            }
        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            Render(e.X, e.Y);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (DialogResult.OK == colorDialog1.ShowDialog())
                {
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = colorDialog1.Color;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _Radius = Convert.ToDouble(textBox1.Text);
            }
            catch (Exception)
            {
                _Radius = 5;
            }
            try
            {
                _Slices = Convert.ToInt32(textBox3.Text);
            }
            catch (Exception)
            {
                _Slices = 5;
            }
        }
    }
}