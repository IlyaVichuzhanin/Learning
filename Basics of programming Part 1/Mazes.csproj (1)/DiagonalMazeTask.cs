namespace Mazes
{
    public static class DiagonalMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            double stepsRight = System.Math.Floor(System.Convert.ToDouble(System.Math.Abs((width - height) / (height - 2)))) + 1;
            double stepsDown = System.Math.Floor(System.Convert.ToDouble(System.Math.Abs((height - width) / (width - 2)))) + 1;
            double countDown = (height - 3) / stepsDown;
            double countRight = (width - 3) / stepsRight;

            if (countDown > countRight)
                MoveDownPath(robot, width, height, countDown);
            else
                MoveRightPath(robot, width, height, countRight);
        }

        public static void MoveRight(Robot robot, int width, int height)
        {
            double stepsRight = System.Math.Floor(System.Convert.ToDouble(System.Math.Abs((width - height) / (height - 2)))) + 1;
            for (int i = 0; i < stepsRight; i++)
            {
                robot.MoveTo(Direction.Right);
            }
        }

        public static void MoveDown(Robot robot, int width, int height)
        {
            double stepsDown = System.Math.Floor(System.Convert.ToDouble(System.Math.Abs((height - width) / (width - 2)))) + 1;
            for (int i = 0; i < stepsDown; i++)
            {
                robot.MoveTo(Direction.Down);
            }
        }

        public static void MoveDownPath(Robot robot, int width, int height, double countDown)
        {
            MoveDown(robot, width, height);
            for (int i = 0; i < countDown - 1; i++)
            {
                MoveRight(robot, width, height);
                MoveDown(robot, width, height);
            }
        }

        public static void MoveRightPath(Robot robot, int width, int height, double countRight)
        {
            MoveRight(robot, width, height);
            for (int i = 0; i < countRight - 1; i++)
            {
                MoveDown(robot, width, height);
                MoveRight(robot, width, height);
            }
        }
    }
}