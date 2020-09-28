using System;
using System.Collections.Generic;
using System.Linq;

namespace T11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> startsWith = (inpText, pattern) => inpText.StartsWith(pattern);
            Func<string, string, bool> endsWith = (inpText, pattern) => inpText.EndsWith(pattern);
            Func<string, string, bool> contains = (inpText, pattern) => inpText.Contains(pattern);
            Func<string, string, bool> lengthIs = (inpText, pattern) => inpText.Length == int.Parse(pattern);
            List<string> appliedForParty = Console.ReadLine().Split().ToList();
            List<string> partyNames = new List<string>(appliedForParty);

            string readLine = "";
            while((readLine = Console.ReadLine()) != "Print")
            {
                string[] commandParts = readLine.Split(";");
                string command = commandParts[0];
                string filterType = commandParts[1];
                string filterParam = commandParts[2];

                if(command.Contains("Add"))
                {
                    if (filterType.Contains("Starts"))
                        partyNames = partyNames.Where(name => !startsWith(name, filterParam)).ToList();
                    else if (filterType.Contains("Ends"))
                        partyNames = partyNames.Where(name => !endsWith(name, filterParam)).ToList();
                    else if (filterType.Contains("Contains"))
                        partyNames = partyNames.Where(name => !contains(name, filterParam)).ToList();
                    else if (filterType.Contains("Length"))
                        partyNames = partyNames.Where(name => !lengthIs(name, filterParam)).ToList();
                }
                else if (command.Contains("Remove"))
                {
                    List<string> restoreNames = new List<string>();
                    if (filterType.Contains("Starts"))
                        restoreNames = appliedForParty.Where(x => startsWith(x, filterParam)).ToList();
                    else if (filterType.Contains("Ends"))
                        restoreNames = appliedForParty.Where(name => endsWith(name, filterParam)).ToList();
                    else if (filterType.Contains("Contains"))
                        restoreNames = appliedForParty.Where(name => contains(name, filterParam)).ToList();
                    else if (filterType.Contains("Length"))
                        restoreNames = appliedForParty.Where(name => lengthIs(name, filterParam)).ToList();
                    HashSet<string> namesToRestore = new HashSet<string>(restoreNames);
                    foreach (string name in namesToRestore)
                        partyNames.Add(name);
                }
            }
            Console.WriteLine(string.Join(" ", partyNames));
        }
    }
}
