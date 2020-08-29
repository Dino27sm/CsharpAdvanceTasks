using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] threeNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> readNum = Console.ReadLine().Split().Select(int.Parse).ToList();
            Stack<int> getStack = new Stack<int>();
            if (threeNum[0] <= 0)
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = 0; i < threeNum[0]; i++)
            {
                if (i < readNum.Count)
                    getStack.Push(readNum[i]);
                else break;
            }
            for (int i = 0; i < threeNum[1]; i++)
            {
                if (getStack.Any())
                    getStack.Pop();
            }
            if(getStack.Contains(threeNum[2]))
                Console.WriteLine("true");
            else if (getStack.Count == 0)
                Console.WriteLine(0);
            else
                Console.WriteLine(getStack.Min());
        }
    }
}
