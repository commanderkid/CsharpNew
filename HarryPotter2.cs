using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            List<List<string>> text = new List<List<string>>();
            text.Add(new List<string>() { "a", "b", "c", "d" });
            text.Add(new List<string>() { "b", "c", "d" });
            text.Add(new List<string>() { "e", "b", "c", "a", "d" });
            Dictionary<string, string> dictionaryForPrinting =
                FrequencyAnalysisTask.GetMostFrequentNextWords(text);
            foreach (KeyValuePair<string, string> pair in dictionaryForPrinting)
                Console.WriteLine("{0} : {1}", pair.Key, pair.Value);
            Console.ReadKey();
        }
    }
    static class FrequencyAnalysisTask
    {   
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            
            Dictionary<string, int> GetMostFrequentNextWords = BinaryTrinary(text);
            return Separator(GetMostFrequentNextWords);
        }

        public static Dictionary<string, int> BinaryTrinary(List<List<string>> text)
        {
            Dictionary<string, int> mainDictionary = new Dictionary<string, int>();
            int lisLen = 0;
            foreach (List<string> list in text)
            {
                lisLen = list.Count;
                if (lisLen > 1)
                    mainDictionary = BinaryTrinaryDictionary(list, lisLen, mainDictionary);
            }
            return mainDictionary;
        }

        public static Dictionary<string, int> BinaryTrinaryDictionary(List<string> text, int lenList, 
                                                                      Dictionary<string, int> mainDictionary)
        {
            for (int i = 0; i < lenList - 1; i++)
                mainDictionary = ThrinaryBinaryStep(mainDictionary, text[i] + " " + text[i + 1]);
            if (lenList > 2)
            {
                for (int i = 0; i < lenList - 2; i++)
                    mainDictionary = ThrinaryBinaryStep(mainDictionary, text[i] + " " +
                                                        text[i + 1] + " " + text[i + 2]);
            }
            return mainDictionary;
        }

        public static Dictionary<string, int> ThrinaryBinaryStep(Dictionary<string, int> mainDictionary, 
                                                                 string pair)
        {
            if (mainDictionary.ContainsKey(pair))
                mainDictionary[pair] += 1;
            else mainDictionary.Add(pair, 1);
            return mainDictionary;
        }

        public static Dictionary<string, string> Separator(Dictionary<string, int> mainDictionary)
        {
            int lenString = 0;
            string stringHolder = null;
            Dictionary<string, string> stringDictionary = new Dictionary<string, string>();
            foreach (KeyValuePair<string, int> pair in mainDictionary)
            {
                stringHolder = pair.Key;
                string[] array = stringHolder.Split(' ');
                lenString = array.Length;
                if (lenString == 2)
                    stringDictionary = BinarySeparator(array, pair.Key, 
                                                       mainDictionary, 
                                                       stringDictionary);
                if (lenString == 3)
                    stringDictionary = PreporatorTrinarySeparator(array, pair.Key,
                                                                  mainDictionary,
                                                                  stringDictionary);
            }
            return stringDictionary;
        }

        public static Dictionary<string, string> BinarySeparator(string[] arr, string pair,
                                                                 Dictionary<string, int> mainDictionary,
                                                                 Dictionary<string, string> stringDictionary)
        {
            string keyOfMainDictionary = null;
            int mainD = 0, mainDP = 0;
            if (stringDictionary.ContainsKey(arr[0]))
            {
                keyOfMainDictionary = arr[0] + " " + stringDictionary[arr[0]];
                mainD = mainDictionary[keyOfMainDictionary];
                mainDP = mainDictionary[pair];
                if (mainD < mainDP)
                    stringDictionary[arr[0]] = arr[1];
                else if (mainD == mainDP &&
                         string.CompareOrdinal(stringDictionary[arr[0]], arr[1]) > 0)
                    stringDictionary[arr[0]] = arr[1];
            }
            else stringDictionary.Add(arr[0], arr[1]);
            return stringDictionary;
        }
        //doitnowBitch
        public static Dictionary<string, string> PreporatorTrinarySeparator(string[] arr, string pair,
                                                         Dictionary<string, int> mainDictionary,
                                                         Dictionary<string, string> stringDictionary)
        {
            string keyOfMainDictionary = pair;
            string keyOfStringDictionary = arr[0] + " " + arr[1];
            int mainD = 0, mainDP = 0;
            if (stringDictionary.ContainsKey(keyOfStringDictionary))
            {
                mainD = mainDictionary[pair];
                mainDP = mainDictionary[keyOfStringDictionary + " " + stringDictionary[keyOfStringDictionary]];
                if (mainD > mainDP)
                    stringDictionary[keyOfStringDictionary] = arr[2];
                else if (mainD == mainDP &&
                         string.CompareOrdinal(stringDictionary[keyOfStringDictionary], arr[2]) > 0)
                    stringDictionary[keyOfStringDictionary] = arr[2];
            }
            else stringDictionary.Add(keyOfStringDictionary, arr[2]);
            return stringDictionary;
        }
    }
}
