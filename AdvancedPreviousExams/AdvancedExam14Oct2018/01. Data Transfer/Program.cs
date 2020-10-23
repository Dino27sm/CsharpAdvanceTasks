using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T01.DataTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            string infoPattern = @"s:(?<sender>[^;]+);r:(?<receiver>[^;]+);m--(?<message>\*[A-Za-z\s]+\*)$";
            Regex regObject = new Regex(infoPattern);
            List<string> inputLines = new List<string>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string thisLine = Console.ReadLine();
                thisLine = thisLine.Replace('"', '*').ToString();
                inputLines.Add(thisLine);
            }
            int totalSum = 0;
            for (int i = 0; i < inputLines.Count; i++)
            {
                Match regMatch = regObject.Match(inputLines[i]);
                if(regMatch.Success)
                {
                    string getSender = regMatch.Groups["sender"].Value;
                    string getReceiver = regMatch.Groups["receiver"].Value;
                    string senderName = GetLetters(getSender);
                    string receiverName = GetLetters(getReceiver);
                    totalSum += (GetDigitsSum(getSender) + GetDigitsSum(getReceiver));
                    string getMessage = regMatch.Groups["message"].Value;
                    getMessage = getMessage.Replace('*', '"').ToString();

                    Console.WriteLine($"{senderName} says {getMessage} to {receiverName}");
                }
            }
            Console.WriteLine($"Total data transferred: {totalSum}MB");
        }

        public static string GetLetters(string inpText)
        {
            char[] arraySymbols = inpText.ToCharArray();
            arraySymbols = arraySymbols.Where(x => char.IsLetter(x) || x == ' ').ToArray();
            return string.Join("", arraySymbols);
        }

        public static int GetDigitsSum(string inpText)
        {
            char[] digits = inpText.ToCharArray().Where(x => char.IsDigit(x)).ToArray();
            return digits.Select(x => int.Parse(x.ToString())).Sum();
        }
    }
}
