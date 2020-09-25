using System;
using System.Linq;

namespace T04.FindEvensOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isOdd = getNum => Math.Abs(getNum) % 2 == 1;
            int[] numRange = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string whatType = Console.ReadLine();
            int firsttNum = numRange[0];
            int lastNum = numRange[1];
            int[] allNumbers = new int[lastNum - firsttNum + 1];
            for (int i = 0; i < allNumbers.Length; i++)
            {
                allNumbers[i] = firsttNum + i;
            }
            if (whatType == "odd")
            {
                allNumbers = allNumbers.Where(x => isOdd(x)).ToArray();
            }
            else
            {
                allNumbers = allNumbers.Where(x => !isOdd(x)).ToArray();
            }
            Console.WriteLine(string.Join(" ", allNumbers));
        }
    }
}
