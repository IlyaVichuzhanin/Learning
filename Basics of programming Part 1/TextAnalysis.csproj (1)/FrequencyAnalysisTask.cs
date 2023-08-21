using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var nGramModelDictionary = new Dictionary<string, string>();
            var frequensyDictionary = GetFrequencyDictionary(text);

            foreach (string nGramm in frequensyDictionary.Keys)
            {
                string mostFriquentWord = frequensyDictionary[nGramm].ElementAt(0).Key;
                int frequency = frequensyDictionary[nGramm].ElementAt(0).Value;
                nGramModelDictionary.Add(nGramm, mostFriquentWord);
                foreach (KeyValuePair<string, int> ending in frequensyDictionary[nGramm])
                {
                    if (ending.Value > frequency)
                    {
                        mostFriquentWord = ending.Key;
                        frequency = ending.Value;
                        nGramModelDictionary[nGramm] = ending.Key;
                    }
                    else if ((ending.Value == frequency) && (String.CompareOrdinal(ending.Key, mostFriquentWord) < 0))
                    {
                        mostFriquentWord = ending.Key;
                        frequency = ending.Value;
                        nGramModelDictionary[nGramm] = ending.Key;
                    }
                }
            }

            return nGramModelDictionary;
        }

        public static Dictionary<string, Dictionary<string, int>> GetFrequencyDictionary(List<List<string>> text)
        {
            var frequensyDictionary = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in text)
            {
                for (int j = 1; j <= 2; j++)
                {
                    string startNGramma;
                    string endNGramma;

                    for (int i = 0; i < sentence.Count - j; i++)
                    {
                        if (j == 1)
                        {
                            startNGramma = sentence[i];
                            endNGramma = sentence[i + 1];
                        }
                        else
                        {
                            startNGramma = sentence[i] + " " + sentence[i + 1];
                            endNGramma = sentence[i + 2];
                        }

                        if (!frequensyDictionary.ContainsKey(startNGramma))
                        {
                            Dictionary<string, int> continiousDictionary = new Dictionary<string, int>();
                            continiousDictionary[endNGramma] = 1;
                            frequensyDictionary[startNGramma] = continiousDictionary;
                        }
                        else
                        {
                            if (!frequensyDictionary[startNGramma].ContainsKey(endNGramma))
                            {
                                Dictionary<string, int> continiousDictionary = new Dictionary<string, int>();
                                continiousDictionary[endNGramma] = 1;
                                frequensyDictionary[startNGramma].Add(endNGramma, continiousDictionary[endNGramma]);
                            }
                            else
                            {
                                frequensyDictionary[startNGramma][endNGramma]++;
                            }
                        }
                    }
                }
            }
            return frequensyDictionary;
        }
    }
}