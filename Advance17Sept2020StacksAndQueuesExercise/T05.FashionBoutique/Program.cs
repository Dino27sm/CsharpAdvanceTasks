using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int countRacks = 0;
            int sumPrices = 0;
            int[] clotheItems = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stackClothes = new Stack<int>(clotheItems);
            int rackCapacity = int.Parse(Console.ReadLine());
            while(stackClothes.Count > 0)
            {
                if(sumPrices + stackClothes.Peek() <= rackCapacity)
                    sumPrices += stackClothes.Pop();
                else
                {
                    countRacks++;
                    sumPrices = 0;
                }
            }
            if (sumPrices > 0) countRacks++;
            Console.WriteLine(countRacks);
        }
    }
}
