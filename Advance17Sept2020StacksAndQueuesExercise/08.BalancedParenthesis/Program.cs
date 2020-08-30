using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string readParentheses = Console.ReadLine();
            Stack<char> stackParentheses = new Stack<char>();
            for (int i = 0; i < readParentheses.Length; i++)
            {
                char currentChar = readParentheses[i];
                if (currentChar == '{' || currentChar == '[' || currentChar == '(')
                    stackParentheses.Push(readParentheses[i]);
                else if (currentChar == '}' || currentChar == ']' || currentChar == ')')
                {
                    if (currentChar == '}') currentChar = '{';
                    else if (currentChar == ']') currentChar = '[';
                    else if (currentChar == ')') currentChar = '(';
                    if (stackParentheses.Any() && stackParentheses.Peek() == currentChar)
                        stackParentheses.Pop();
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            if (stackParentheses.Any())
                Console.WriteLine("NO");
            else
                Console.WriteLine("YES");
        }
    }
}
