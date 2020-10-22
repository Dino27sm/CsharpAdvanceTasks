using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            string[] readLine = Console.ReadLine().Split();
            Stack<string> hallsStack = new Stack<string>();
            for (int i = 0; i < readLine.Length; i++)
            {
                hallsStack.Push(readLine[i]);
            }
            Queue<char> hallNames = new Queue<char>();
            List<int> hallPrint = new List<int>();
            int sumGroups = 0;
            while(hallsStack.Count > 0)
            {
                string getElement = hallsStack.Pop();
                if (char.IsLetter(getElement[0]))
                {
                    hallNames.Enqueue(getElement[0]);
                }
                else
                {
                    if (hallNames.Any())
                    {
                        int groupNum = int.Parse(getElement);
                        if (sumGroups + groupNum > capacity)
                        {
                            hallsStack.Push(getElement);
                            Console.WriteLine($"{hallNames.Dequeue()} -> {string.Join(", ", hallPrint)}");
                            hallPrint.Clear();
                            sumGroups = 0;
                        }
                        else
                        {
                            hallPrint.Add(groupNum);
                            sumGroups += groupNum;
                        }
                    }
                }
            }
        }
    }
}
