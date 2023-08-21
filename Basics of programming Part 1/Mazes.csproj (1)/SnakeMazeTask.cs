namespace Mazes
{
    public static class SnakeMazeTask
    {
        public static void MoveOut(Robot robot, int width, int height)
        {
            for (int k = 0; k < ((height - 1) / 4 - 1); k++)
            {
                MoveRight(robot, width);
                Move2StepsDown(robot);
                MoveLeft(robot, width);
                Move2StepsDown(robot);
            }
            MoveRight(robot, width);
            Move2StepsDown(robot);
            MoveLeft(robot, width);
        }

        public static void MoveRight(Robot robot, int width)
        {
            for (int i = 0; i < width - 3; i++)
            {
                robot.MoveTo(Direction.Right);
            }
        }

        public static void MoveLeft(Robot robot, int width)
        {
            for (int i = 0; i < width - 3; i++)
            {
                robot.MoveTo(Direction.Left);
            }
        }

        public static void Move2StepsDown(Robot robot)
        {
            for (int j = 0; j < 2; j++)
            {
                robot.MoveTo(Direction.Down);
            }
        }
    }
}