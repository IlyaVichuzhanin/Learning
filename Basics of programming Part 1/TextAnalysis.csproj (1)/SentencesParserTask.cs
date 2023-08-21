using System.Collections.Generic;
using System;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var wordList = new List<List<string>>();
            var sentenceList = new List<string>();
            var symbols = new char[] { '.', '!', '?', ';', ':', '(', ')' };

            var sentences = text.ToLower().Split(symbols, StringSplitOptions.RemoveEmptyEntries);
            foreach (var sentence in sentences)
            {
                sentenceList.Add(sentence.Trim());
            }
            foreach (var sentence in sentenceList)
            {
                if ((sentence.Length != 0) && (WordParse(sentence).Count != 0))
                    wordList.Add(WordParse(sentence));
            }

            return wordList;
        }

        public static List<string> WordParse(string sentance)
        {
            var words = new List<string>();
            string word = "";
            for (int i = 0; i < sentance.Length; i++)
            {
                if ((i == sentance.Length - 1) && (char.IsLetter(sentance[i]) || sentance[i] == '\''))
                {
                    word = word + sentance[i];
                    words.Add(word);
                }
                else if (char.IsLetter(sentance[i]) || sentance[i] == '\'')
                {
                    word = word + sentance[i];
                }
                else
                {
                    if ((word != ""))
                    {
                        words.Add(word);
                        word = "";
                    }
                }
            }
            return words;
        }
    }
}