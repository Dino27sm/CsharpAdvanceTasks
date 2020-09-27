using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace T10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> startsWith = (inpString, pattern) => inpString.StartsWith(pattern);
            Func<string, string, bool> endsWith = (inpString, pattern) => inpString.EndsWith(pattern);
            Func<string, string, bool> withLength = (inpString, length) => inpString.Length == int.Parse(length);
            List<string> partyNames = Console.ReadLine().Split().ToList();
            string commandLine = "";
            while((commandLine = Console.ReadLine()) != "Party!")
            {
                string[] commandParts = commandLine.Split();
                string whatToDo = commandParts[0];
                string checkWhat = commandParts[1];
                string parameter = commandParts[2];
                if (whatToDo == "Remove")
                {
                    if(checkWhat == "StartsWith")
                        partyNames = partyNames.Where(x => !startsWith(x, parameter)).ToList();
                    else if (checkWhat == "EndsWith")
                        partyNames = partyNames.Where(x => !endsWith(x, parameter)).ToList();
                    else if (checkWhat == "Length")
                        partyNames = partyNames.Where(x => !withLength(x, parameter)).ToList();
                }
                else if (whatToDo == "Double")
                {
                    List<string> wordsToDouble = new List<string>();
                    if (checkWhat == "StartsWith")
                        wordsToDouble = partyNames.Where(x => startsWith(x, parameter)).ToList();
                    else if (checkWhat == "EndsWith")
                        wordsToDouble = partyNames.Where(x => endsWith(x, parameter)).ToList();
                    else if (checkWhat == "Length")
                        wordsToDouble = partyNames.Where(x => withLength(x, parameter)).ToList();
                    if (wordsToDouble.Count > 0)
                    {
                        HashSet<string> wordsToSet = new HashSet<string>(wordsToDouble);
                        for (int i = 0; i < partyNames.Count; i++)
                        {
                            foreach (string setWord in wordsToSet)
                            {
                                if (partyNames[i] == setWord)
                                    partyNames.Insert(i++, setWord);
                            }
                        }
                    }
                }
            }
            if(partyNames.Count > 0)
                Console.WriteLine(string.Join(", ", partyNames) + " are going to the party!");
            else
                Console.WriteLine("Nobody is going to the party!");
        }
    }
}
