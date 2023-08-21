using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class Decoder2
    {
        private static string ApplyCommands(string[] commands)
        {
            var message = new StringBuilder();
            string commandWord;
            foreach (var command in commands)
            {
                commandWord = command.Split(' ')[0];
                if (commandWord == "push")
                    message.Append(command.Substring(5));
                else
                    message.Remove(message.Length - Int32.Parse(command.Split(' ')[1]), Int32.Parse(command.Split(' ')[1]));
            }
            return message.ToString();
        }
    }
}
