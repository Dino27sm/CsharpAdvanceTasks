using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int, List<int>> whichNotDevided = (x, y) => x.Where(z => z % y != 0).ToList();
            List<int> readInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            int devidor = int.Parse(Console.ReadLine());
            readInput.Reverse();
            readInput = whichNotDevided(readInput, devidor).ToList();
            Console.WriteLine(string.Join(" ", readInput));
        }
    }
}
