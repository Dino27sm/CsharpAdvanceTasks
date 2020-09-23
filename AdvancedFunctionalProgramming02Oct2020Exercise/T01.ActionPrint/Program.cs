using System;

namespace T01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] readWords = Console.ReadLine().Split(" ");
            Action<string> printText = textToPrint => Console.WriteLine(textToPrint);
            foreach (string word in readWords)
                printText(word);
        }
    }
}
