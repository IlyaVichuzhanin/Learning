// В этом пространстве имен содержатся средства для работы с изображениями. 
// Чтобы оно стало доступно, в проект был подключен Reference на сборку System.Drawing.dll
using System.Drawing;
using System;

namespace Fractals
{
    internal static class DragonFractalTask
    {
        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            double x = 1;
            double y = 0;
            double tempx;
            double tempy;
            var random = new Random(seed);
            pixels.SetPixel(x, y);
            for (int i = 0; i < iterationsCount; i++)
            {
                var nextNumber = random.Next(2);
                if (nextNumber == 0)
                {
                    tempx = DoRotationOne(x, y)[0];
                    tempy = DoRotationOne(x, y)[1];
                }
                else
                {
                    tempx = DoRotationTwo(x, y)[0];
                    tempy = DoRotationTwo(x, y)[1];
                }
                x = tempx;
                y = tempy;
                pixels.SetPixel(x, y);
            }
        }

        public static double[] DoRotationOne(double x, double y)
        {
            double[] tempcoords = new double[2];
            tempcoords[0] = (x * Math.Cos(Math.PI / 4) - y * Math.Sin(Math.PI / 4)) / Math.Sqrt(2);
            tempcoords[1] = (x * Math.Sin(Math.PI / 4) + y * Math.Cos(Math.PI / 4)) / Math.Sqrt(2);
            return tempcoords;
        }

        public static double[] DoRotationTwo(double x, double y)
        {
            double[] tempcoords = new double[2];
            tempcoords[0] = (x * Math.Cos(3 * Math.PI / 4) - y * Math.Sin(3 * Math.PI / 4)) / Math.Sqrt(2) + 1;
            tempcoords[1] = (x * Math.Sin(3 * Math.PI / 4) + y * Math.Cos(3 * Math.PI / 4)) / Math.Sqrt(2);
            return tempcoords;
        }
        /*
		Начните с точки (1, 0)
		Создайте генератор рандомных чисел с сидом seed

		На каждой итерации:

		1. Выберите случайно одно из следующих преобразований и примените его к текущей точке:

			Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз):
			x' = (x · cos(45°) - y · sin(45°)) / sqrt(2)
			y' = (x · sin(45°) + y · cos(45°)) / sqrt(2)

			Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу):
			x' = (x · cos(135°) - y · sin(135°)) / sqrt(2) + 1
			y' = (x · sin(135°) + y · cos(135°)) / sqrt(2)

		2. Нарисуйте текущую точку методом pixels.SetPixel(x, y)

		*/
    }
}