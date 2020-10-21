using System;
using System.Collections.Generic;
using System.Linq;

namespace Т01.SantaPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] materials = Console.ReadLine()?
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] magicValues = Console.ReadLine()?
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> matarialStack = new Stack<int>(materials);
            Queue<int> magicQueue = new Queue<int>(magicValues);
            Dictionary<int, string> magicPresentDict = new Dictionary<int, string>();
            magicPresentDict[150] = "Doll";
            magicPresentDict[250] = "Wooden train";
            magicPresentDict[300] = "Teddy bear";
            magicPresentDict[400] = "Bicycle";
            SortedDictionary<string, int> presents = new SortedDictionary<string, int>();

            while(matarialStack.Count > 0 && magicQueue.Count > 0)
            {
                int product = matarialStack.Peek() * magicQueue.Peek();
                if (product == 0)
                {
                    if (matarialStack.Peek() == 0)
                        matarialStack.Pop();
                    if (magicQueue.Peek() == 0)
                        magicQueue.Dequeue();
                }
                else if (product < 0)
                {
                    int sumMaterialMagic = matarialStack.Pop() + magicQueue.Dequeue();
                    matarialStack.Push(sumMaterialMagic);
                }
                else if (product > 0)
                {
                    if (magicPresentDict.ContainsKey(product))
                    {
                        if (!presents.ContainsKey(magicPresentDict[product]))
                            presents.Add(magicPresentDict[product], 0);
                        presents[magicPresentDict[product]]++;
                        magicQueue.Dequeue();
                        matarialStack.Pop();
                    }
                    else
                    {
                        magicQueue.Dequeue();
                        matarialStack.Push(matarialStack.Pop() + 15);
                    }
                }
            }
            bool checkPresents = (presents.ContainsKey("Doll") && presents.ContainsKey("Wooden train")) ||
                (presents.ContainsKey("Teddy bear") && presents.ContainsKey("Bicycle"));
            if (checkPresents)
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            else
                Console.WriteLine("No presents this Christmas!");

            if (matarialStack.Count > 0)
                Console.WriteLine($"Materials left: " + string.Join(", ", matarialStack));
            if (magicQueue.Count > 0)
                Console.WriteLine($"Magic left: " + string.Join(", ", magicQueue));

            foreach (var item in presents.Where(x => x.Value > 0))
                Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
