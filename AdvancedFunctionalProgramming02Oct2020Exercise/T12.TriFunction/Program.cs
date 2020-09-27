using System;
using System.Collections.Generic;
using System.Linq;

namespace T12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int readSumChar = int.Parse(Console.ReadLine());
            List<string> listNames = Console.ReadLine().Split().ToList();
            Func<string, int> returnCharSum = inpString => inpString.Select(x => (int)x).Sum();
            for (int i = 0; i < listNames.Count; i++)
            {
                if(returnCharSum(listNames[i]) >= readSumChar)
                {
                    Console.WriteLine(listNames[i]);
                    break;
                }
            }
        }
    }
}
