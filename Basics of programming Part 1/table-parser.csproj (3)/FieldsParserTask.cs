using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class FieldParserTaskTests
    {
        public static void Test(string input, string[] expectedResult)
        {
            var actualResult = FieldsParserTask.ParseLine(input);
            Assert.AreEqual(expectedResult.Length, actualResult.Count);
            for (int i = 0; i < expectedResult.Length; ++i)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i].Value);
            }
        }

        [TestCase("text", new[] { "text" })]
        [TestCase("hello world", new[] { "hello", "world" })]
        [TestCase("hello  world", new[] { "hello", "world" })]
        [TestCase(@"""b c d e""", new[] { "b c d e" })]
        [TestCase(@"""b c d e", new[] { "b c d e" })]
        [TestCase(@"'a\' b'", new[] { "a' b" })]
        [TestCase(@"'a"" b'", new[] { @"a"" b" })]
        [TestCase(@"""a' b""", new[] { @"a' b" })]
        [TestCase(@"a""b", new[] { "a", "b" })]
        [TestCase("", new string[0])]
        [TestCase(" a", new[] { "a" })]
        [TestCase("\"\\\\a\"", new[] { "\\a" })]
        [TestCase("\"\\\\a\\\\\"", new[] { "\\a\\" })]
        [TestCase(@"""b c d e ", new[] { "b c d e " })]
        [TestCase(@"""abc\""cde""", new[] { "abc\"cde" })]
        [TestCase("\"ab\" bc", new[] { "ab", "bc" })]
        [TestCase("\"\"", new[] { "" })]

        public static void RunTests(string input, string[] expectedOutput)
        {
            Test(input, expectedOutput);
        }
    }

    public class FieldsParserTask
    {
        // При решении этой задаче постарайтесь избежать создания методов, длиннее 10 строк.
        // Подумайте как можно использовать ReadQuotedField и Token в этой задаче.
        public static List<Token> ParseLine(string line)
        {
            List<Token> fields = new List<Token>();
            Token field = new Token("", 0, 0);
            int startIndex = 0;
            char[] charArray = line.ToCharArray();
            while (startIndex < line.Length)
            {
                if ((line[startIndex] == '\"') || (line[startIndex] == '\''))
                {
                    fields.Add(ReadQuotedField(line, startIndex));
                    startIndex = ReadQuotedField(line, startIndex).GetIndexNextToToken();
                }
                else if (line[startIndex] == ' ')
                {
                    startIndex = SkipSpases(line, startIndex);
                }
                else
                {
                    fields.Add(ReadField(line, startIndex));
                    startIndex = ReadField(line, startIndex).GetIndexNextToToken();
                }
            }
            return fields;
        }

        private static Token ReadField(string line, int startIndex)
        {
            int length = 1;
            int endField = startIndex;
            for (int i = startIndex; i < line.Length; i++)
            {
                //if (i == line.Length - 1)
                //    break;
                if ((line[i + 1] == ' ') || (line[i + 1] == '\"') || (line[i + 1] == '\''))
                {
                    endField = i;
                    length = endField - startIndex + 1;
                    break;
                }
            }
            string tokenLine = line.Substring(startIndex, length);
            return new Token(tokenLine, startIndex, length);
        }

        private static int SkipSpases(string line, int startIndex)
        {
            while ((startIndex < line.Length) && (line[startIndex] == ' '))
                startIndex++;
            return startIndex;
        }

        public static Token ReadQuotedField(string line, int startIndex)
        {
            char firstQuote = line[startIndex];
            int length = 1;
            int secondQuotePosition = 0;
            string tokenLine = "";
            for (int i = startIndex + 1; i < line.Length; i++)
            {
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