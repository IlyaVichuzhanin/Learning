using System.Threading;

namespace func_rocket;

public class ControlTask
{
	public static Turn ControlRocket(Rocket rocket, Vector target)
	{
		var r = rocket;
		return Turn.Left;
	}
}