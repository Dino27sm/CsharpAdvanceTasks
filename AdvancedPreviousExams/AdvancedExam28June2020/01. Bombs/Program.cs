using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> bombCount = new SortedDictionary<string, int>();
            bombCount["Cherry Bombs"] = 0;
            bombCount["Datura Bombs"] = 0;
            bombCount["Smoke Decoy Bombs"] = 0;

            Dictionary<int, string> bombData = new Dictionary<int, string>();
            bombData[40] = "Datura Bombs";
            bombData[60] = "Cherry Bombs";
            bombData[120] = "Smoke Decoy Bombs";

            int[] bombEfects = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] bombCasing = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> effectsQueue = new Queue<int>(bombEfects);
            Stack<int> casingStack = new Stack<int>(bombCasing);

            bool filledPouch = false;
            while(effectsQueue.Count > 0 && casingStack.Count > 0)
            {
                int sumEffectCasing = effectsQueue.Peek() + casingStack.Peek();
                if (bombData.ContainsKey(sumEffectCasing))
                {
                    bombCount[bombData[sumEffectCasing]]++;
                    effectsQueue.Dequeue();
                    casingStack.Pop();
                }
                else
                {
                    casingStack.Push(casingStack.Pop() - 5);
                }
                if (bombCount.All(x => x.Value >= 3))
                {
                    filledPouch = true;
                    break;
                }
            }
            if (filledPouch)
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            else
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");

            if(effectsQueue.Count > 0)
            {
                int[] effectsRemain = effectsQueue.ToArray();
                Console.WriteLine("Bomb Effects: " + string.Join(", ", effectsRemain));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casingStack.Count > 0)
            {
                int[] casingsRemain = casingStack.ToArray();
                Console.WriteLine("Bomb Casings: " + string.Join(", ", casingsRemain));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            foreach (var item in bombCount)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
