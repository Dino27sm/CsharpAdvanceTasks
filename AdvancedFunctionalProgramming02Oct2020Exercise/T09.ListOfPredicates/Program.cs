using System;
using System.Collections.Generic;
using System.Linq;

namespace T09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int upRange = int.Parse(Console.ReadLine());
            int[] deviders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> allNum = new List<int>();
            for (int i = 1; i <= upRange; i++)
                allNum.Add(i);
            Func<int, int[], bool> checkDeviders = (inpNum, deviders) =>
            {
                bool devided = true;
                for (int i = 0; i < deviders.Length; i++)
                {
                    if (inpNum % deviders[i] != 0)
                        devided = false;
                }
                return devided;
            };
            Console.WriteLine(string.Join(" ", allNum.Where(x => checkDeviders(x, deviders))));
        }
    }
}
