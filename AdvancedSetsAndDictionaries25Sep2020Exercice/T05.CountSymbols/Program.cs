using System;
using System.Collections.Generic;

namespace T05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charData = new SortedDictionary<char, int>();
            char[] readText = Console.ReadLine().ToCharArray();
            for (int i = 0; i < readText.Length; i++)
            {
                if (!charData.ContainsKey(readText[i]))
                {
                    charData.Add(readText[i], 0);
                }
                charData[readText[i]]++;
            }
            foreach (var kvp in charData)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
