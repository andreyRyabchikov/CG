using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CGLab1
{

    //Метод Sobel принимает изображение и выполняет оператор Собеля для выделения границ.
    //Он проходит по каждому пикселю изображения и применяет оператор Собеля к его окрестности. 
    //Затем сумма квадратов производных по X и Y для каждой компоненты цвета проверяется на превышение порога limit.
    //Если сумма превышает порог, цвет пикселя устанавливается на черный, иначе на белый.
    //Результат сохраняется в новом Bitmap res. 
    //После завершения операции вызывается событие OnDone, в котором передается результат операции в виде изображения типа Image.
    class Method
    {
        // Определение делегата для события обновления прогресса
        public delegate void Progress(int i);
        // Событие обновления прогресса
        public event Progress OnProgress;

        // Определение делегата для события обновления количества
        public delegate void Amount(int i);
        // Событие обновления количества
        public event Amount OnAmount;

        // Определение делегата для события завершения
        public delegate void Done(Image img);
        // Событие завершения
        public event Done OnDone;

        // Ограничение для суммы квадратов производных
        public static int limit = 128 * 128;

        // Метод для применения оператора Собеля к изображению
        public void Sobel(Image img)
        {
            // Преобразование изображения в Bitmap
            Bitmap b = new Bitmap(img);
            int width = b.Width;
            int height = b.Height;

            // Вызов события обновления количества строк
            OnAmount(height);

            // Создание нового Bitmap для результата
            Bitmap res = new Bitmap(width, height);

            // Операторы Собеля для вычисления производных по X и Y
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            // Массивы для хранения значений компонентов цвета каждого пикселя
            int[,] allPixR = new int[width, height];
            int[,] allPixG = new int[width, height];
            int[,] allPixB = new int[width, height];

            // Получение значений компонентов цвета для каждого пикселя
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allPixR[i, j] = b.GetPixel(i, j).R;
                    allPixG[i, j] = b.GetPixel(i, j).G;
                    allPixB[i, j] = b.GetPixel(i, j).B;
                }
            }

            int dxR, dyR;
            int dxG, dyG;
            int dxB, dyB;
            int rc, gc, bc;

            // Применение оператора Собеля к каждому пикселю
            for (int j = 1; j < b.Height - 1; j++)
            {
                // Вызов события обновления прогресса
                OnProgress(j);

                for (int i = 1; i < b.Width - 1; i++)
                {
                    dxR = 0; dyR = 0;
                    dxG = 0; dyG = 0;
                    dxB = 0; dyB = 0;
                    rc = 0; gc = 0; bc = 0;

                    // Применение операторов Собеля к окрестности пикселя
                    for (int wi = -1; wi < 2; wi++)
                    {
                        for (int hw = -1; hw < 2; hw++)
                        {
                            // Вычисление производных по X и Y для каждой компоненты цвета
                            rc = allPixR[i + hw, j + wi];
                            dxR += gx[wi + 1, hw + 1] * rc;
                            dyR += gy[wi + 1, hw + 1] * rc;

                            gc = allPixG[i + hw, j + wi];
                            dxG += gx[wi + 1, hw + 1] * gc;
                            dyG += gy[wi + 1, hw + 1] * gc;

                            bc = allPixB[i + hw, j + wi];
                            dxB += gx[wi + 1, hw + 1] * bc;
                            dyB += gy[wi + 1, hw + 1] * bc;
                        }
                    }

                    // Пороговая проверка суммы квадратов производных и установка цвета пикселя в соответствии с результатом
                    if (dxR * dxR + dyR * dyR > limit || dxG * dxG + dyG * dyG > limit || dxB * dxB + dyB * dyB > limit)
                        res.SetPixel(i, j, Color.Black);
                    else
                        res.SetPixel(i, j, Color.White);
                }
            }

            // Вызов события завершения и передача результата
            OnDone(res);
        }
    }
}