using System;
using System.Collections.Generic;
using System.Drawing;
using RoutePlanning;

namespace RoutePlanning
{
    public static class PathFinderTask
    {
        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            var bestOrder = MakeTrivialPermutation(checkpoints.Length);
            var orders = new List<int[]>();
            var order = new int[checkpoints.Length];
            double[] minPathLength = new double[1] { PointExtensions.GetPathLength(checkpoints, bestOrder) };
            FindBestOrder(checkpoints, 1, orders, minPathLength, bestOrder, order);
            return bestOrder;
        }

        private static int[] MakeTrivialPermutation(int size)
        {
            var bestOrder = new int[size];
            for (int i = 0; i < bestOrder.Length; i++)
                bestOrder[i] = i;
            return bestOrder;
        }

        public static void FindBestOrder(
            Point[] checkpoints,
            int position,
            List<int[]> orders,
            double[] minPathLength,
            int[] bestOrder,
            int[] order)
        {
            if (position == checkpoints.Length)
            {
                if (PointExtensions.GetPathLength(checkpoints, order) < minPathLength[0])
                {
                    for (int i = 0; i < order.Length; i++)
                        bestOrder[i] = order[i];
                    minPathLength[0] = PointExtensions.GetPathLength(checkpoints, order);
                }
                return;
            }
            for (int i = 0; i < checkpoints.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < position; j++)
                {
                    if (order[j] == i)
                    {
                        found = true;
                        break;
                    }
                }
                if (found) continue;
                order[position] = i;
                FindBestOrder(checkpoints, position + 1, orders, minPathLength, bestOrder, order);
            }
        }
    }
}