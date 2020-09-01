using System;
using System.Collections.Generic;
using System.Linq;

namespace T11.KeyRevolverM1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackBullets = new Stack<int>();
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelCapacity = int.Parse(Console.ReadLine());
            int[] readBullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queLocks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int budgetValue = int.Parse(Console.ReadLine());
            int numBullets = readBullets.Length;
            if(budgetValue < numBullets * bulletPrice)
                numBullets = budgetValue / bulletPrice;

            for (int i = 0; i < numBullets; i++)
            {
                stackBullets.Push(readBullets[i]);
            }
            int countBullets = 0;
            while(stackBullets.Count > 0)
            {
                if (countBullets < barrelCapacity)
                {
                    if (queLocks.Count > 0)
                    {
                        countBullets++;
                        budgetValue -= bulletPrice;
                        int currentBullet = stackBullets.Pop();
                        if (currentBullet <= queLocks.Peek())
                        {
                            queLocks.Dequeue();
                            Console.WriteLine("Bang!");
                        }
                        else Console.WriteLine("Ping!");
                    }
                    else break;
                }
                else
                {
                    Console.WriteLine("Reloading!");
                    countBullets = 0;
                }

            }
            if (queLocks.Any())
                Console.WriteLine($"Couldn't get through. Locks left: {queLocks.Count}");
            else
                Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${budgetValue}");
        }
    }
}
