using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int allFood = int.Parse(Console.ReadLine());
            Queue<int> clientsQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Console.WriteLine($"{clientsQueue.Max()}");
            while(clientsQueue.Count > 0)
            {
                if (clientsQueue.Peek() <= allFood)
                    allFood -= clientsQueue.Dequeue();
                else break;
            }
            if(clientsQueue.Count > 0)
            {
                Console.Write("Orders left: ");
                Console.WriteLine(string.Join(" ", clientsQueue));
            }
            else Console.WriteLine("Orders complete");
        }
    }
}
