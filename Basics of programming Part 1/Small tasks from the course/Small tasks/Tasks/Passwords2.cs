using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class Passwords2
    {
        public class CaseAlternatorTask
        {
            //Тесты будут вызывать этот метод
            public static List<string> AlternateCharCases(string lowercaseWord)
            {
                var result = new List<string>();
                //lowercaseWord= lowercaseWord.ToLower();
                //result.Add(lowercaseWord);
                AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
                //result.Sort();
                return result;
            }

            static void AlternateCharCases(char[] word, int startIndex, List<string> result)
            {
                if (startIndex == word.Length)
                {
                    result.Add(new string(word));
                    return;
                }
                if (Char.IsLetter(word[startIndex]) && (char.ToUpper(word[startIndex]) != char.ToLower(word[startIndex])))
                {
                    word[startIndex] = char.ToLower(word[startIndex]);
                    AlternateCharCases(word, startIndex + 1, result);
                    word[startIndex] = char.ToUpper(word[startIndex]);
                    AlternateCharCases(word, startIndex + 1, result);
                }
                else
                {
                    AlternateCharCases(word, startIndex + 1, result);
                }
            }
        }
    }
}
