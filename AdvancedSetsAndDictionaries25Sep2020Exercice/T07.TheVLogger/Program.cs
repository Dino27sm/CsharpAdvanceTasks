using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace T07.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> vloggerFollowers = new Dictionary<string, SortedSet<string>>();
            Dictionary<string, SortedSet<string>> vloggerFollowings = new Dictionary<string, SortedSet<string>>();

            while (true)
            {
                string[] readLine = Console.ReadLine().Split();
                if (readLine[0] == "Statistics") 
                    break;  // End While
                string majorCommand = readLine[1];
                if(majorCommand == "joined")
                {
                    string vloggerName = readLine[0];
                    if (!vloggerFollowers.ContainsKey(vloggerName))
                    {
                        vloggerFollowers.Add(vloggerName, new SortedSet<string>());
                        vloggerFollowings.Add(vloggerName, new SortedSet<string>());
                    }
                }
                else if (majorCommand == "followed")
                {
                    string vlogerOne = readLine[0];
                    string vlogerTwo = readLine[2];
                    if(vloggerFollowers.ContainsKey(vlogerOne) && vloggerFollowers.ContainsKey(vlogerTwo))
                    {
                        if(vlogerOne != vlogerTwo)
                        {
                            vloggerFollowers[vlogerTwo].Add(vlogerOne);
                            vloggerFollowings[vlogerOne].Add(vlogerTwo);
                        }
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vloggerFollowers.Count} vloggers in its logs.");
            int counterOne = 1;
            foreach (var kvp in vloggerFollowers.OrderByDescending(x => x.Value.Count)
                .ThenBy(y => vloggerFollowings[y.Key].Count))
            {
                Console.WriteLine($"{counterOne}. {kvp.Key} : {kvp.Value.Count} followers, {vloggerFollowings[kvp.Key].Count} following");
                if (counterOne == 1)
                {
                    foreach (var item in kvp.Value)
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
                counterOne++;
            }
        }
    }
}
