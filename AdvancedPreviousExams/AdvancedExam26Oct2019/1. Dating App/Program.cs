using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] maleRead = Console.ReadLine().Split().Select(x => int.Parse(x)).Where(x => x > 0).ToArray();
            int[] femaleRead = Console.ReadLine().Split().Select(int.Parse).Where(x => x > 0).ToArray();
            Stack<int> maleStack = new Stack<int>(maleRead);
            Queue<int> femaleQueue = new Queue<int>(femaleRead);
            int countMatches = 0;
            while(maleStack.Count > 0 && femaleQueue.Count > 0)
            {
                int maleValue = maleStack.Peek();
                int femaleValue = femaleQueue.Peek();
                if (maleValue % 25 == 0)
                {
                    maleStack.Pop();
                    if (maleStack.Count > 0)
                        maleStack.Pop();
                    else
                        break;
                    continue;
                }
                if (femaleValue % 25 == 0)
                {
                    femaleQueue.Dequeue();
                    if (femaleQueue.Count > 0)
                        femaleQueue.Dequeue();
                    else
                        break;
                    continue;
                }
                if (maleValue == femaleValue)
                {
                    countMatches++;
                    maleStack.Pop();
                    femaleQueue.Dequeue();
                }
                else
                {
                    femaleQueue.Dequeue();
                    if (maleStack.Peek() -2 <= 0) maleStack.Pop();
                    else maleStack.Push(maleStack.Pop() - 2);
                }
            }
            Console.WriteLine($"Matches: {countMatches}");
            if (maleStack.Count > 0)
                Console.WriteLine($"Males left: {string.Join(", ", maleStack)}");
            else
                Console.WriteLine("Males left: none");

            if (femaleQueue.Count > 0)
                Console.WriteLine($"Females left: {string.Join(", ", femaleQueue)}");
            else
                Console.WriteLine("Females left: none");
        }
    }
}
