using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            string entirePhrase = phraseBeginning.ToLower();
            for (int i = 0; i < wordsCount; i++)
            {
                string[] phraseArray = entirePhrase.Split(' ');
                int phraseLength = phraseArray.Length;
                if (phraseArray.Length == 1)
                {
                    if (nextWords.ContainsKey(phraseArray[0]))
                    {
                        entirePhrase = phraseBeginning + " " + nextWords[phraseArray[0]];
                    }
                }
                else
                {
                    if (nextWords.ContainsKey(phraseArray[phraseLength - 2] + " " + phraseArray[phraseLength - 1]))
                    {
                        entirePhrase = entirePhrase + " "
                            + nextWords[phraseArray[phraseLength - 2]
                            + " " + phraseArray[phraseLength - 1]];
                    }
                    else if (nextWords.ContainsKey(phraseArray[phraseLength - 1]))
                    {
                        entirePhrase = entirePhrase + " " + nextWords[phraseArray[phraseLength - 1]];
                    }
                }
            }

            return entirePhrase;
        }
    }
}