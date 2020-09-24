using System;
using System.Linq;

namespace T03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] readNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> getMin = number => number.Min();
            int getResult = getMin(readNum);
            Console.WriteLine(getResult);
        }
    }
}
