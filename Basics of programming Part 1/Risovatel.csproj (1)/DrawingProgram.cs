using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Drawing
    {
        static float x, y;
        static Graphics graphics;

        public static void Initialize(Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        { x = x0; y = y0; }

        public static void MakeIt(Pen pensil, double length, double tetta)
        {
            //Делает шаг длиной dlina в направлении ugol и рисует пройденную траекторию
            var x1 = (float)(x + length * Math.Cos(tetta));
            var y1 = (float)(y + length * Math.Sin(tetta));
            graphics.DrawLine(pensil, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double length, double tetta)
        {
            x = (float)(x + length * Math.Cos(tetta));
            y = (float)(y + length * Math.Sin(tetta));
        }
    }

    public class ImpossibleSquare
    {
        static void DrawFirstLine(int shirina, int visota)
        {
            var sz = Math.Min(shirina, visota);
            Drawing.MakeIt(Pens.Yellow, sz * 0.375f, 0);
            Drawing.MakeIt(Pens.Yellow, sz * 0.04f * Math.Sqrt(2), Math.PI / 4);
            Drawing.MakeIt(Pens.Yellow, sz * 0.375f, Math.PI);
            Drawing.MakeIt(Pens.Yellow, sz * 0.375f - sz * 0.04f, Math.PI / 2);

            Drawing.Change(sz * 0.04f, -Math.PI);
            Drawing.Change(sz * 0.04f * Math.Sqrt(2), 3 * Math.PI / 4);
        }

        static void DrawSecondLine(int shirina, int visota)
        {
            var sz = Math.Min(shirina, visota);
            Drawing.MakeIt(Pens.Yellow, sz * 0.375f, -Math.PI / 2);
            Drawing.MakeIt(Pens.Yellow, sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
            Drawing.MakeIt(Pens.Yellow, sz * 0.375f, -Math.PI / 2 + Math.PI);
            Drawing.MakeIt(Pens.Yellow, sz * 0.375f - sz * 0.04f, -Math.PI / 2 + Math.PI / 2);

            Drawing.Change(sz * 0.04f, -Math.PI / 2 - Math.PI);
            Drawing.Change(sz * 0.04f * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);
        }

        static void DrawThirdLine(int shirina, int visota)
        {
            var sz = Math.Min(shirina, visota);
            Drawing.MakeIt(Pens.Yellow, sz * 0.375f, Math.PI);
            Drawing.MakeIt(Pens.Yellow, sz * 0.04f * Math.Sqrt(2), Math.PI + Math.PI / 4);
            Drawing.MakeIt(Pens.Yellow, sz * 0.375f, Math.PI + Math.PI);
            Drawing.MakeIt(Pens.Yellow, sz * 0.375f - sz * 0.04f, Math.PI + Math.PI / 2);

            Drawing.Change(sz * 0.04f, Math.PI - Math.PI);
            Drawing.Change(sz * 0.04f * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);
        }

        static void DrawForthLine(int shirina, int visota)
        {
            var sz = Math.Min(shirina, visota);
            Drawing.MakeIt(Pens.Yellow, sz * 0.375f, Math.PI / 2);
            Drawing.MakeIt(Pens.Yellow, sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
            Drawing.MakeIt(Pens.Yellow, sz * 0.375f, Math.PI / 2 + Math.PI);
            Drawing.MakeIt(Pens.Yellow, sz * 0.375f - sz * 0.04f, Math.PI / 2 + Math.PI / 2);

            Drawing.Change(sz * 0.04f, Math.PI / 2 - Math.PI);
            Drawing.Change(sz * 0.04f * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }

        public static void Draw(int shirina, int visota, double tao, Graphics graphics)
        {
            // ugolPovorota пока не используется, но будет использоваться в будущем
            Drawing.Initialize(graphics);

            var sz = Math.Min(shirina, visota);

            var diagonal_length = Math.Sqrt(2) * (sz * 0.375f + sz * 0.04f) / 2;
            var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + shirina / 2f;
            var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + visota / 2f;

            Drawing.SetPosition(x0, y0);


            //Рисуем 1-ую сторону
            DrawFirstLine(shirina, visota);
            //Рисуем 2-ую сторону
            DrawSecondLine(shirina, visota);
            //Рисуем 3-ю сторону
            DrawThirdLine(shirina, visota);
            //Рисуем 4-ую сторону
            DrawForthLine(shirina, visota);
        }
    }
}