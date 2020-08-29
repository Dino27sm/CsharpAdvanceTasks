using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numCommands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] readNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queueNums = new Queue<int>();
            if (numCommands[0] > 0 && numCommands[0] < readNum.Length)
            {
                for (int i = 0; i < numCommands[0]; i++)
                    queueNums.Enqueue(readNum[i]);
            }
            else queueNums = new Queue<int>(readNum);
            for (int i = 1; i <= numCommands[1]; i++)
            {
                if (queueNums.Count > 0)
                    queueNums.Dequeue();
                else break;
            }
            if (queueNums.Contains(numCommands[2]))
                Console.WriteLine("true");
            else if (queueNums.Count == 0)
                Console.WriteLine(0);
            else
                Console.WriteLine(queueNums.Min());
        }
    }
}
