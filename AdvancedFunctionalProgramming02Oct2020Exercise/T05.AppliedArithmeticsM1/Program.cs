using System;
using System.Linq;

namespace T05.AppliedArithmeticsM1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inpArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string commandRead = "";
            while((commandRead = Console.ReadLine()) != "end")
            {
                if (commandRead == "print")
                {
                    Console.WriteLine(string.Join(" ", inpArray));
                    continue;
                }
                inpArray = ManipulateArray(inpArray, commandRead);
            }
        }
        static int[] ManipulateArray(int[] inpArray, string command)
        {
            int[] outArray = inpArray.ToArray();
            if (command == "add") outArray = outArray.Select(x => x + 1).ToArray();
            else if (command == "subtract") outArray = outArray.Select(x => x - 1).ToArray();
            else if (command == "multiply") outArray = outArray.Select(x => x * 2).ToArray();
            return outArray;
        }
    }
}
