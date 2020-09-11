using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.SetsElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> hashOne = new HashSet<int>();
            HashSet<int> hashTwo = new HashSet<int>();
            int[] linesNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstHash = linesNum[0];
            int secondHash = linesNum[1];
            for (int i = 0; i < firstHash; i++)
            {
                hashOne.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < secondHash; i++)
            {
                hashTwo.Add(int.Parse(Console.ReadLine()));
            }
            Dictionary<int, int> loadHashOne = new Dictionary<int, int>();
            foreach (var item in hashOne)
            {
                loadHashOne.Add(item, 1);
            }
            foreach (var item in hashTwo)
            {
                if (loadHashOne.ContainsKey(item))
                {
                    loadHashOne[item]++;
                }
            }
            Console.WriteLine(string.Join(" ", loadHashOne.Where(x => x.Value == 2).Select(x => x.Key)));
        }
    }
}
