using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    public class WhiteSpaceRemover
    {
        public static string RemoveStartSpaces(string text)
        {
            while (char.IsWhiteSpace(text[0]) && text.Length > 0)
            {
                text = text.Substring(1);
                if (text.Length == 0) break;
            }
            return text;
        }
    }
}
