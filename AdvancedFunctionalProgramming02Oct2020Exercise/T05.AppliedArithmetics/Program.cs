using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<double>> printAction = getList => Console.WriteLine(string.Join(" ", getList));
            Func<List<double>, List<double>> addOne = inpList => inpList.Select(x => x + 1).ToList();
            Func<List<double>, List<double>> multiplyByTwo = inpList => inpList.Select(x => x * 2).ToList();
            Func<List<double>, List<double>> subtractOne = inpList => inpList.Select(x => x - 1).ToList();

            List<double> allNum = Console.ReadLine().Split().Select(double.Parse).ToList();
            string command = "";
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    allNum = addOne(allNum).ToList();
                }
                else if (command == "multiply")
                {
                    allNum = multiplyByTwo(allNum).ToList();
                }
                else if (command == "subtract")
                {
                    allNum = subtractOne(allNum).ToList();
                }
                else if (command == "print")
                {
                    printAction(allNum);
                }
            }
        }
    }
}
