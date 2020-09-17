using System;
using System.Collections.Generic;
using System.Linq;

namespace T12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsValue = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] botlsValue = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> cupsQueue = new Queue<int>(cupsValue);
            Stack<int> botlStack = new Stack<int>(botlsValue);
            int remainWater = 0;
            while (true)
            {
                if(cupsQueue.Count > 0)
                {
                    if(botlStack.Count > 0)
                    {
                        if (botlStack.Peek() - cupsQueue.Peek() >= 0)
                        {
                            remainWater += (botlStack.Pop() - cupsQueue.Dequeue());
                        }
                        else
                        {
                            int currentCup = cupsQueue.Peek() - botlStack.Pop();
                            while(botlStack.Count > 0)
                            {
                                if(currentCup - botlStack.Peek() > 0)
                                {
                                    currentCup -= botlStack.Pop();
                                }
                                else
                                {
                                    remainWater += (botlStack.Pop() - currentCup);
                                    cupsQueue.Dequeue();
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        string remainCups = string.Join(" ", cupsQueue);
                        Console.WriteLine($"Cups: {remainCups}");
                        Console.WriteLine($"Wasted litters of water: {remainWater}");
                        return;
                    }
                }
                else
                {
                    string remainBottles = string.Join(" ", botlStack);
                    Console.WriteLine($"Bottles: {remainBottles}");
                    Console.WriteLine($"Wasted litters of water: {remainWater}");
                    return;
                }
            }
        }
    }
}
