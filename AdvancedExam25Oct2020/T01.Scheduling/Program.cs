using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> taskStack = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threadQueue = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int taskGoal = int.Parse(Console.ReadLine());

            while(taskStack.Count > 0 && threadQueue.Count > 0)
            {
                int getTask = taskStack.Peek();
                int getThread = threadQueue.Peek();
                if (getTask == taskGoal)
                {
                    Console.WriteLine($"Thread with value {getThread} killed task {getTask}");
                    Console.WriteLine(string.Join(" ", threadQueue));
                    return;
                }
                if (getThread >= getTask)
                {
                    taskStack.Pop();
                    threadQueue.Dequeue();
                }
                else
                {
                    threadQueue.Dequeue();
                }
            }
        }
    }
}
