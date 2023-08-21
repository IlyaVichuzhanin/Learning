using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double a = Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
            double b = Math.Sqrt((x - bx) * (x - bx) + (y - by) * (y - by));
            double c = Math.Sqrt((bx - ax) * (bx - ax) + (by - ay) * (by - ay));
            double p = 0.5 * (a + b + c);
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            double h = 2 * s / c;
            double cosA = -(b * b - a * a - c * c) / (2 * a * c);
            double cosB = -(a * a - b * b - c * c) / (2 * b * c);


            if (c == 0)
            {
                return Math.Sqrt((bx - x) * (bx - x) + (by - y) * (by - y));
            }
            else if (cosA <= 0 || cosB <= 0)
            {
                return Math.Min(a, b);
            }
            else
            {
                return h;
            }
        }
    }
}