using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class WhiteBoard
    {
        private static void WriteBoard(int size)
        {
            string line = "";
            for (int j = 1; j <= size; j++)
            {
                if (j % 2 == 1)
                {
                    line = "#";
                }
                else
                {
                    line = ".";
                }
                for (int i = 0; i < size - 1; i++)
                {
                    if (line[i] == '#')
                    {
                        line = line + '.';
                    }
                    else
                    {
                        line = line + '#';
                    }
                }
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }
}
