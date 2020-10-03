using System;
using System.Linq;

namespace T05.AppliedArithmeticsM2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inpArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Action<int[]> printArray = arrayToPrint => Console.WriteLine(string.Join(" ", arrayToPrint));
            string getCommand = "";
            Func<int, int> manipulateNum = num => ManipulateNumber(num, getCommand);
            while((getCommand = Console.ReadLine()) != "end")
            {
                if (getCommand == "print") printArray(inpArr);
                else inpArr = inpArr.Select(x => manipulateNum(x)).ToArray();
            }
        }
        static int ManipulateNumber(int inpNum, string command)
        {
            if (command == "add") inpNum++;
            if (command == "subtract") inpNum--;
            if (command == "multiply") inpNum *= 2;
            return inpNum;
        } 
    }
}
