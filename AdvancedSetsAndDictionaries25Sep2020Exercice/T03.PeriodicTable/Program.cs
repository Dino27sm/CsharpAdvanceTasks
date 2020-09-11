using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> chemicElements = new SortedSet<string>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                string[] readLine = Console.ReadLine().Split();
                for (int k = 0; k < readLine.Length; k++)
                {
                    chemicElements.Add(readLine[k]);
                }
            }
            Console.WriteLine(string.Join(" ", chemicElements));
        }
    }
}
