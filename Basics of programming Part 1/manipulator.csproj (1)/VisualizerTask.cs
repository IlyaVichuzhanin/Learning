using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.Keys;
using static Manipulation.Manipulator;
using static System.Windows.Forms.MouseEventArgs;
using static Manipulation.ManipulatorTask;


namespace Manipulation
{
    public static class VisualizerTask
    {
        public static double X = 220;
        public static double Y = -100;
        public static double Alpha = 0.05;
        public static double Wrist = 2 * Math.PI / 3;
        public static double Elbow = 3 * Math.PI / 4;
        public static double Shoulder = Math.PI / 2;

        public static Brush UnreachableAreaBrush = new SolidBrush(Color.FromArgb(255, 255, 230, 230));
        public static Brush ReachableAreaBrush = new SolidBrush(Color.FromArgb(255, 230, 255, 230));
        public static Pen ManipulatorPen = new Pen(Color.Black, 3);
        public static Brush JointBrush = Brushes.Gray;

        public static void KeyDown(Form form, KeyEventArgs key)
        {
            double increment = 0.1;
            var keyCode = key.KeyCode;
            if (keyCode == Q)
                Shoulder += increment;

            if (keyCode == A)
                Shoulder -= increment;

            if (keyCode == W)
                Elbow += increment;

            if (keyCode == S)
                Elbow -= increment;

            Wrist = -Alpha - Shoulder - Elbow;

            // TODO: Добавьте реакцию на QAWS и пересчитывать Wrist
            form.Invalidate();
        }


        public static void MouseMove(Form form, MouseEventArgs e)
        {
            // TODO: Измените X и Y пересчитав координаты (e.X, e.Y) в логические.
            var sholderPosition = GetShoulderPos(form);
            var newMouseCoordinates = ConvertWindowToMath(new PointF(e.X, e.Y), sholderPosition);

            X = newMouseCoordinates.X;
            Y = newMouseCoordinates.Y;

            UpdateManipulator();
            form.Invalidate();
        }

        public static void MouseWheel(Form form, MouseEventArgs e)
        {
            Alpha += e.Delta;// TODO: Измените Alpha, используя e.Delta — размер прокрутки колеса мыши
            UpdateManipulator();
            form.Invalidate();
        }

        public static void UpdateManipulator()
        {
            var arrayOfAngles = MoveManipulatorTo(X, Y, Alpha);
            if (!double.IsNaN(arrayOfAngles[0]))
            {
                Shoulder = arrayOfAngles[0];
                Elbow = arrayOfAngles[1];
                Wrist = arrayOfAngles[2];
            }

            // Вызовите ManipulatorTask.MoveManipulatorTo и обновите значения полей Shoulder, Elbow и Wrist, 
            // если они не NaN. Это понадобится для последней задачи.
        }

        public static void DrawManipulator(Graphics graphics, PointF shoulderPos)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(Shoulder, Elbow, Wrist);

            graphics.DrawString(
                $"X={X:0}, Y={Y:0}, Alpha={Alpha:0.00}",
                new Font(SystemFonts.DefaultFont.FontFamily, 12),
                Brushes.DarkRed,
                10,
                10);
            DrawReachableZone(graphics, ReachableAreaBrush, UnreachableAreaBrush, shoulderPos, joints);

            graphics.DrawLine(ManipulatorPen, ConvertMathToWindow(new PointF(0, 0), shoulderPos), ConvertMathToWindow(joints[0], shoulderPos));
            graphics.DrawLine(ManipulatorPen, ConvertMathToWindow(joints[0], shoulderPos), ConvertMathToWindow(joints[1], shoulderPos));
            graphics.DrawLine(ManipulatorPen, ConvertMathToWindow(joints[1], shoulderPos), ConvertMathToWindow(joints[2], shoulderPos));

            graphics.FillEllipse(JointBrush, new RectangleF(shoulderPos, new SizeF(1, 1)));
            graphics.FillEllipse(JointBrush, new RectangleF(joints[0], new SizeF(1, 1)));
            graphics.FillEllipse(JointBrush, new RectangleF(joints[1], new SizeF(1, 1)));
            graphics.FillEllipse(JointBrush, new RectangleF(joints[2], new SizeF(1, 1)));

            // Нарисуйте сегменты манипулятора методом graphics.DrawLine используя ManipulatorPen.
            // Нарисуйте суставы манипулятора окружностями методом graphics.FillEllipse используя JointBrush.
            // Не забудьте сконвертировать координаты из логических в оконные
        }

        private static void DrawReachableZone(
            Graphics graphics,
            Brush reachableBrush,
            Brush unreachableBrush,
            PointF shoulderPos,
            PointF[] joints)
        {
            var rmin = Math.Abs(Manipulator.UpperArm - Manipulator.Forearm);
            var rmax = Manipulator.UpperArm + Manipulator.Forearm;
            var mathCenter = new PointF(joints[2].X - joints[1].X, joints[2].Y - joints[1].Y);
            var windowCenter = ConvertMathToWindow(mathCenter, shoulderPos);
            graphics.FillEllipse(reachableBrush, windowCenter.X - rmax, windowCenter.Y - rmax, 2 * rmax, 2 * rmax);
            graphics.FillEllipse(unreachableBrush, windowCenter.X - rmin, windowCenter.Y - rmin, 2 * rmin, 2 * rmin);
        }

        public static PointF GetShoulderPos(Form form)
        {
            return new PointF(form.ClientSize.Width / 2f, form.ClientSize.Height / 2f);
        }

        public static PointF ConvertMathToWindow(PointF mathPoint, PointF shoulderPos)
        {
            return new PointF(mathPoint.X + shoulderPos.X, shoulderPos.Y - mathPoint.Y);
        }

        public static PointF ConvertWindowToMath(PointF windowPoint, PointF shoulderPos)
        {
            return new PointF(windowPoint.X - shoulderPos.X, shoulderPos.Y - windowPoint.Y);
        }
    }
}