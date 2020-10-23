using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.CupsBottlesM1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsArray = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
            Stack<int> cups = new Stack<int>(cupsArray);
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedWater = 0;
            int waterOut = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                waterOut = bottles.Pop() - cups.Pop();
                if (waterOut >= 0)
                {
                    wastedWater += waterOut;
                    waterOut = 0;
                }
                else 
                    cups.Push(Math.Abs(waterOut));
            }
            if (bottles.Count > 0)
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            if (cups.Count > 0)
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
