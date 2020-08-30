using System;
using System.Collections.Generic;

namespace T09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            string textOut = "";
            Stack<string> oldStack = new Stack<string>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] commandParts = Console.ReadLine().Split();
                int majorCommand = int.Parse(commandParts[0]);
                if(majorCommand == 1)
                {
                    string textAppend = commandParts[1];
                    oldStack.Push(textOut);
                    textOut += textAppend;
                }
                else if (majorCommand == 2)
                {
                    int numDelete = int.Parse(commandParts[1]);
                    oldStack.Push(textOut);
                    textOut = textOut.Substring(0, textOut.Length - numDelete).ToString();
                }
                else if (majorCommand == 3)
                {
                    int printIndex = int.Parse(commandParts[1]);
                    Console.WriteLine(textOut[printIndex - 1]);
                }
                else if (majorCommand == 4)
                    textOut = oldStack.Pop().ToString();
            }
        }
    }
}
