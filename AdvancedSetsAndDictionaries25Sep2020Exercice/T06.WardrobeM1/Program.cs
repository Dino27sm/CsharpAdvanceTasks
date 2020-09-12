using System;
using System.Collections.Generic;

namespace T06.WardrobeM1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dressColor = new Dictionary<string, Dictionary<string, int>>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] infoParts = Console.ReadLine().Split(" -> ");
                string getColor = infoParts[0];
                string[] currentDresses = infoParts[1].Split(",");
                if (!dressColor.ContainsKey(getColor))
                {
                    dressColor.Add(getColor, new Dictionary<string, int>());
                }
                for (int k = 0; k < currentDresses.Length; k++)
                {
                    if (!dressColor[getColor].ContainsKey(currentDresses[k]))
                    {
                        dressColor[getColor].Add(currentDresses[k], 0);
                    }
                    dressColor[getColor][currentDresses[k]]++;
                }
            }
            string[] findClothes = Console.ReadLine().Split();
            string colorFind = findClothes[0];
            string clothFind = findClothes[1];
            foreach (var kvp in dressColor)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var item in kvp.Value)
                {
                    if (kvp.Key == colorFind && item.Key == clothFind)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
