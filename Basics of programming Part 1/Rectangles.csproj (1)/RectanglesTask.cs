using System;

namespace Rectangles
{
    public static class RectanglesTask
    {
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
            return ((r2.Left + r2.Width) >= r1.Left) && (r2.Left <= (r1.Left + r1.Width)) && (Math.Min(r1.Top + r1.Height, r2.Top + r2.Height) >= Math.Max(r1.Top, r2.Top));
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (AreIntersected(r1, r2))
            {
                return (Math.Min(r2.Left + r2.Width, r1.Left + r1.Width) - Math.Max(r1.Left, r2.Left)) * (Math.Min(r2.Top + r2.Height, r1.Top + r1.Height) - Math.Max(r1.Top, r2.Top));
            }
            else
            {
                return 0;
            }
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            if (((r1.Left <= r2.Left) && (r1.Top <= r2.Top)) && ((r1.Left + r1.Width) >= (r2.Left + r2.Width)) && ((r1.Top + r1.Height) >= (r2.Top + r2.Height)))
            {
                return 1;
            }
            else if (((r2.Left <= r1.Left) && (r2.Top <= r1.Top)) && ((r2.Left + r2.Width) >= (r1.Left + r1.Width)) && ((r2.Top + r2.Height) >= (r1.Top + r1.Height)))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}