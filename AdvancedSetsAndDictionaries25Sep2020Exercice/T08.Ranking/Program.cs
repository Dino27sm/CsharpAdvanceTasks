using System;
using System.Collections.Generic;
using System.Linq;

namespace T08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPwd = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> userContestPoints = new SortedDictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string readFirstPart = Console.ReadLine();
                if(readFirstPart == "end of contests")
                {
                    break;
                }
                string[] getContestInfo = readFirstPart.Split(":");
                string contestName = getContestInfo[0];
                string password = getContestInfo[1];
                if (!contestPwd.ContainsKey(contestName))
                {
                    contestPwd.Add(contestName, password);
                }
            }
            while (true)
            {
                string readSecondPart = Console.ReadLine();
                if(readSecondPart == "end of submissions")
                {
                    break;
                }
                string[] getResults = readSecondPart.Split("=>");
                string contestName = getResults[0];
                string password = getResults[1];
                string userName = getResults[2];
                int points = int.Parse(getResults[3]);
                if(contestPwd.ContainsKey(contestName) && contestPwd[contestName] == password)
                {
                    if (!userContestPoints.ContainsKey(userName))
                    {
                        userContestPoints.Add(userName, new Dictionary<string, int>());
                        userContestPoints[userName].Add(contestName, points);
                    }
                    else
                    {
                        if (!userContestPoints[userName].ContainsKey(contestName))
                        {
                            userContestPoints[userName].Add(contestName, points);
                        }
                        else
                        {
                            if(userContestPoints[userName][contestName] < points)
                            {
                                userContestPoints[userName][contestName] = points;
                            }
                        }
                    }
                }
            }
            string bestUser = "";
            int maxSum = int.MinValue;
            foreach (var kvp in userContestPoints)
            {
                int tempSum = 0;
                foreach (var item in kvp.Value)
                {
                    tempSum += item.Value;
                }
                if (maxSum < tempSum)
                {
                    maxSum = tempSum;
                    bestUser = kvp.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestUser} with total {maxSum} points.");
            Console.WriteLine("Ranking:");
            foreach (var kvp in userContestPoints)
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var item in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
