using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numEvens = new Dictionary<int, int>();
            int numLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numLines; i++)
            {
                int readNum = int.Parse(Console.ReadLine());
                if (!numEvens.ContainsKey(readNum))
                {
                    numEvens.Add(readNum, 0);
                }
                numEvens[readNum]++;
            }
            Console.WriteLine(string.Join(" ", numEvens.Where(x => x.Value % 2 == 0).Select(y => y.Key)));
        }
    }
}
