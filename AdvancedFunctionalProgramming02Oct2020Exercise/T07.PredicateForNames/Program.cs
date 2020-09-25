using System;
using System.Collections.Generic;
using System.Linq;

namespace T07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int readNum = int.Parse(Console.ReadLine());
            List<string> getNames = Console.ReadLine().Split().ToList();
            Func<List<string>, int, List<string>> checkNames = (x, y) => x.Where(z => z.Length <= y).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, checkNames(getNames, readNum)));
        }
    }
}
