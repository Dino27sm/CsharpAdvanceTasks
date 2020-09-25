using System;
using System.Collections.Generic;
using System.Linq;

namespace T08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> returnEvens = inpList => inpList.Where(x => Math.Abs(x) % 2 == 0).ToList();
            Func<List<int>, List<int>> returnOdds = inpList => inpList.Where(x => Math.Abs(x) % 2 == 1).ToList();
            List<int> readNum = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> sortedEvens = returnEvens(readNum).OrderBy(x => x).ToList();
            List<int> sortedOdds = returnOdds(readNum).OrderBy(x => x).ToList();
            List<int> resultList = sortedEvens.Concat(sortedOdds).ToList();
            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
