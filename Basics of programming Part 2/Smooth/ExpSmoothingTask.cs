using System.Collections.Generic;
using System.Linq;

namespace yield
{
    public static class ExpSmoothingTask
    {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            bool firstValue = true;
            double previousExpSmothedValue = 0;
            double currentExpSmothedValue;
            foreach (DataPoint point in data)
            {
                if (firstValue)
                {
                    firstValue = false;
                    yield return point.WithExpSmoothedY(point.OriginalY);
                    previousExpSmothedValue = point.OriginalY;
                }
                else
                {
                    currentExpSmothedValue = alpha * point.OriginalY + (1 - alpha) * previousExpSmothedValue;
                    yield return point.WithExpSmoothedY(currentExpSmothedValue);
                    previousExpSmothedValue = currentExpSmothedValue;
                }
            }
        }
    }
}
