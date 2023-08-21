using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class MiddleOfThreeTask
    {
        static IComparable MiddleOfThree(IComparable a, IComparable b, IComparable c)
        {
            if (a.CompareTo(b) > 0)
            {
                if (a.CompareTo(c) > 0)
                {
                    if (c.CompareTo(b) > 0)
                    {
                        return c;
                    }
                    else
                    {
                        return b;
                    }
                }
                else
                {
                    return a;
                }
            }
            else
            {
                if (a.CompareTo(c) > 0)
                {
                    return a;
                }
                else
                {
                    if (b.CompareTo(c) < 0)
                    {
                        return b;
                    }
                    else
                    {
                        return c;
                    }
                }
            }
        }
    }
}
