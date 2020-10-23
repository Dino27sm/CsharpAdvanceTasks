using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> userData = new Dictionary<string, Dictionary<string, int>>();
            string readLine = "";
            while((readLine = Console.ReadLine()) != "end")
            {
                string[] infoParts = readLine.Split(new string[] { "->", " " }, StringSplitOptions.RemoveEmptyEntries);
                string firstItem = infoParts[0];
                if (firstItem == "ban")
                {
                    string banUser = infoParts[1];
                    if (userData.ContainsKey(banUser))
                        userData.Remove(banUser);
                }
                else
                {
                    string userName = firstItem.ToString();
                    string tag = infoParts[1];
                    int likes = int.Parse(infoParts[2]);
                    if (!userData.ContainsKey(userName))
                    {
                        userData.Add(userName, new Dictionary<string, int>());
                        userData[userName].Add(tag, likes);
                    }
                    else
                    {
                        if (!userData[userName].ContainsKey(tag))
                            userData[userName].Add(tag, likes);
                        else
                            userData[userName][tag] += likes;
                    }
                }
            }
            foreach (var kvp in userData.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(y => y.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var item in kvp.Value)
                    Console.WriteLine($"- {item.Key}: {item.Value}");
            }
        }
    }
}
