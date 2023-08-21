using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Chapter_1
{
    internal class Robot
    {
        static bool ShouldFire2(bool enemyInFront, string enemyName, int robotHealth)
        {
            return enemyInFront && ((enemyName == "boss" && robotHealth >= 50) || enemyName != "boss");
        }
    }
}
