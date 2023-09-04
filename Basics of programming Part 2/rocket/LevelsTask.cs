using System;
using System.Collections.Generic;

namespace func_rocket;

public class LevelsTask
{
	static readonly Physics standardPhysics = new();

    public static Vector CreateGravityVector(
            double gravityForceValue, double gravityDirectionAngleInRad)
    {
        var x = Math.Round(Math.Cos(gravityDirectionAngleInRad), 1);
        var y = Math.Round(Math.Sin(gravityDirectionAngleInRad), 1);
        return new Vector(x, y) * gravityForceValue;
    }

    public static double GetForceAngle1(Vector v, Vector target)
    {
        var forceVector = v-target;
        return forceVector.Angle;
    }

    public static double GetForceAngle2(Vector v, Vector target)
    {
        var forceVector = target - v;
        return forceVector.Angle;
    }



    public static IEnumerable<Level> CreateLevels()
	{
		yield return new Level("Zero", 
			new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
			new Vector(600, 200), 
			(size, v) => Vector.Zero, standardPhysics);

        yield return new Level("Heavy",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(600, 200),
                (size, v) =>
                {
                    return CreateGravityVector(0.9, Math.PI / 2);
                },
                standardPhysics);
        yield return new Level("Up",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(700, 500),
                (size, v) =>
                {
                    var d = Math.Sqrt((size.Y - v.Y) * (size.Y - v.Y));   
                    var gravityForce = 300.0 / (d + 300.0);
                    return CreateGravityVector(gravityForce, 3 * Math.PI / 2);
                },
                standardPhysics);

        yield return new Level("WhiteHole",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(600, 200),
                (size, v) =>
                {
                    var d = Math.Sqrt((600 - v.X) * (600 - v.X) + (200 - v.Y) * (200 - v.Y));
                    var gravityForce = 140.0 * d / (d * d + 1);
                    return CreateGravityVector(gravityForce, GetForceAngle1(v, new Vector(600, 200)));
                },
                standardPhysics);

        yield return new Level("BlackHole",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(600, 200),
                (size, v) =>
                {
                    var d = Math.Sqrt((400 - v.X) * (400 - v.X) + (350 - v.Y) * (350 - v.Y));
                    var gravityForce = 300.0 * d / (d * d + 1);
                    return CreateGravityVector(gravityForce, GetForceAngle2(v, new Vector(400, 350)));
                },
                standardPhysics);


        yield return new Level("BlackAndWhite",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(600, 200),
                (size, v) =>
                {
                    var dWhiteHole = Math.Sqrt((600 - v.X) * (600 - v.X) + (200 - v.Y) * (200 - v.Y));
                    var dBlackHole = Math.Sqrt((400 - v.X) * (400 - v.X) + (350 - v.Y) * (350 - v.Y));
                    var gravityForceWhiteHole = 140.0 * dWhiteHole / (dWhiteHole * dWhiteHole + 1);
                    var gravityForceBlackHole = 300.0 * dBlackHole / (dBlackHole * dBlackHole + 1);
                    
                    var whiteHoleForce = CreateGravityVector(gravityForceWhiteHole, GetForceAngle1(v, new Vector(600, 200)));
                    var blackHoleForce = CreateGravityVector(gravityForceBlackHole, GetForceAngle2(v, new Vector(400, 350)));

                    var totalForce = (whiteHoleForce + blackHoleForce) / 2;

                    return totalForce;
                },
                standardPhysics);
    }
}