using System;
using NUnit.Framework;
using static System.Math;
using static Manipulation.Manipulator;
using static Manipulation.TriangleTask;

namespace Manipulation
{
    public static class ManipulatorTask
    {
        /// <summary>
        /// Возвращает массив углов (shoulder, elbow, wrist),
        /// необходимых для приведения эффектора манипулятора в точку x и y 
        /// с углом между последним суставом и горизонталью, равному alpha (в радианах)
        /// См. чертеж manipulator.png!
        /// </summary>
        public static double[] MoveManipulatorTo(double x, double y, double alpha)
        {
            var wristPosX = x + Palm * Cos(PI - alpha);
            var wristPosY = y + Palm * Sin(PI - alpha);
            var distance = Sqrt(x * x + y * y);
            var possibleDistance = (double)(UpperArm + Forearm + Palm);

            var wristToCenterDistance = Sqrt(wristPosX * wristPosX + wristPosY * wristPosY);
            var elbow = GetABAngle(UpperArm, Forearm, wristToCenterDistance);

            var sholder1 = GetABAngle(UpperArm, wristToCenterDistance, Forearm);
            var sholder2 = Atan2(wristPosY, wristPosX);
            var sholder = sholder1 + sholder2;

            var wrist = -alpha - sholder - elbow;

            if (double.IsNaN(sholder) || double.IsNaN(elbow) || double.IsNaN(wrist))
                return new[] { double.NaN, double.NaN, double.NaN };
            return new[] { sholder, elbow, wrist };
        }
    }

    [TestFixture]
    public class ManipulatorTask_Tests
    {
        [Test]
        public void TestMoveManipulatorTo()
        {
            Random rnd = new Random();
            var x = rnd.Next();
            var y = rnd.Next();
            var angle = rnd.NextDouble() * 2 * PI;
            var angles = ManipulatorTask.MoveManipulatorTo(x, y, angle);
            if (!Double.IsNaN(angles[0]))
            {
                var coordinates = AnglesToCoordinatesTask.GetJointPositions(angles[0], angles[1], angles[2]);
                Assert.AreEqual(x, coordinates[2].X, 1e-5);
                Assert.AreEqual(y, coordinates[2].Y, 1e-5);
            }
        }
    }
}