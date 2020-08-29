using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.MaximumMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackBuild = new Stack<int>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                int[] commandParts = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (commandParts[0] == 1)
                {
                    stackBuild.Push(commandParts[1]);
                }
                else if (commandParts[0] == 2)
                {
                    if(stackBuild.Count > 0)
                        stackBuild.Pop();
                }
                else if (commandParts[0] == 3)
                {
                    if (stackBuild.Count > 0)
                        Console.WriteLine(stackBuild.Max());
                }
                else if (commandParts[0] == 4)
                {
                    if (stackBuild.Count > 0)
                        Console.WriteLine(stackBuild.Min());
                }
            }
            Console.WriteLine(string.Join(", ", stackBuild));
        }
    }
}
