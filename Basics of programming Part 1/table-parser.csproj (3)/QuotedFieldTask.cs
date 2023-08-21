using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        [TestCase("''", 0, "", 2)]
        [TestCase("'a'", 0, "a", 3)]
        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        }

        // Добавьте свои тесты
    }

    class QuotedFieldTask
    {
        public static Token ReadQuotedField(string line, int startIndex)
        {
            char firstQuote = line[startIndex];
            int length = 1;
            int secondQuotePosition = 0;
            string tokenLine = "";
            for (int i = startIndex + 1; i < line.Length; i++)
            {
                char ch = line[i];
                if ((i != line.Length - 2) && (line[i] == '\\') && (line[i + 1] == '\''))
                {
                    i++;
                    continue;
                }
                else if ((line[i] == firstQuote))
                {
                    secondQuotePosition = i;
                    length = secondQuotePosition - startIndex + 1;
                    tokenLine = line.Substring(startIndex + 1, length - 2);
                    break;
                }
                else if ((i == line.Length - 1))
                {
                    secondQuotePosition = i + 1;
                    length = line.Length - startIndex;
                    tokenLine = line.Substring(startIndex + 1, secondQuotePosition - startIndex - 1);
                }
            }
            tokenLine = tokenLine.Replace("\\", "");
            return new Token(tokenLine, startIndex, length);
        }
    }
}
