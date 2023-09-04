using System;

namespace func_rocket;

public class ForcesTask
{
	/// <summary>
	/// Создает делегат, возвращающий по ракете вектор силы тяги двигателей этой ракеты.
	/// Сила тяги направлена вдоль ракеты и равна по модулю forceValue.
	/// </summary>
	public static RocketForce GetThrustForce(double forceValue)
	{
		return r => new Vector(forceValue * Math.Cos(r.Direction), forceValue * Math.Sin(r.Direction));
    }

	/// <summary>
	/// Преобразует делегат силы гравитации, в делегат силы, действующей на ракету
	/// </summary>
	public static RocketForce ConvertGravityToForce(Gravity gravity, Vector spaceSize)
    {
        return r =>
        {
            return gravity(spaceSize, r.Location);
        }; 
        
    }
    /// <summary>
    /// Суммирует все переданные силы, действующие на ракету, и возвращает суммарную силу.
    /// </summary>
    public static RocketForce Sum(params RocketForce[] forces)
	{
        return r =>
        {
            double X = 0;
            double Y = 0;
            foreach (var force in forces)
            {
                X += force(r).X;
                Y += force(r).Y;
            }
            return new Vector(X, Y);
        };
    }
}