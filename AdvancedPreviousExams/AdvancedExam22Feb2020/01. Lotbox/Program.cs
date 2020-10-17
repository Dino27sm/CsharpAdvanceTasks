using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] readFirstBox = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int[] readSecondBox = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            Queue<int> firstBox = new Queue<int>(readFirstBox);
            Stack<int> secondBox = new Stack<int>(readSecondBox);

            int sumLoot = 0;
            while(firstBox.Count > 0 && secondBox.Count > 0)
            {
                int sumTwoElements = firstBox.Peek() + secondBox.Peek();
                if(sumTwoElements % 2 == 0)
                {
                    sumLoot += sumTwoElements;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }
            if(firstBox.Count == 0)
                Console.WriteLine("First lootbox is empty");

            if (secondBox.Count == 0)
                Console.WriteLine("Second lootbox is empty");

            if (sumLoot >= 100)
                Console.WriteLine($"Your loot was epic! Value: {sumLoot}");
            else
                Console.WriteLine($"Your loot was poor... Value: {sumLoot}");
        }
    }
}
