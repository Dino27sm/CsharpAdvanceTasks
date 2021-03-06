﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.CupsBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedWater = 0;
            int waterOut = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int aCup = cups.Peek();
                if (waterOut < 0) 
                    aCup = waterOut;
                int aBottle = bottles.Peek();
                waterOut = aBottle - Math.Abs(aCup);
                if(waterOut >= 0)
                {
                    wastedWater += waterOut;
                    cups.Dequeue();
                    bottles.Pop();
                    waterOut = 0;
                }
                else
                    bottles.Pop();
            }
            if (bottles.Count > 0)
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            if (cups.Count > 0)
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
