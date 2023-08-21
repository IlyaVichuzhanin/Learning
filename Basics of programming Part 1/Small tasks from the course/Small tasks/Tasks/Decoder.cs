using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class Decoder
    {
        private static string DecodeMessage(string[] lines)
        {
            List<string> message = new List<string>();
            string allLines = "";

            foreach (string line in lines)
                allLines = allLines + " " + line;
            string[] allWords = allLines.Split(' ');

            foreach (string word in allWords)
                if (word != "" && Char.IsUpper(word[0]))
                    message.Add(word);
            message.Reverse();
            return String.Join(" ", message.ToArray());
        }
    }
}
