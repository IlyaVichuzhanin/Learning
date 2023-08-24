using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace yield
{
    public static class MovingAverageTask
    {
        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
        {
            var windowQueue = new Queue<DataPoint>();
            double queueSum = 0;
            foreach (DataPoint point in data)
            {
                if (windowQueue.Count < windowWidth)
                {
                    queueSum += point.OriginalY;
                }
                else
                {
                    queueSum = queueSum - windowQueue.Dequeue().OriginalY + point.OriginalY;
                }

                windowQueue.Enqueue(point);

                yield return point.WithAvgSmoothedY(queueSum / windowQueue.Count);
            }
        }
    }
}