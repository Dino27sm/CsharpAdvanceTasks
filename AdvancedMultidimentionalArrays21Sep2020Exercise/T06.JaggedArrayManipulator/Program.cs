using System;
using System.Linq;

namespace T06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesNum = int.Parse(Console.ReadLine());
            double[][] jaggArray = new double[linesNum][];
            for (int row = 0; row < linesNum; row++)
            {
                double[] readLine = Console.ReadLine().Split().Select(double.Parse).ToArray();
                jaggArray[row] = new double[readLine.Length];
                for (int col = 0; col < readLine.Length; col++)
                    jaggArray[row][col] = readLine[col];
            }
            if (jaggArray.Length > 1)
            {
                for (int row = 1; row < jaggArray.Length; row++)
                {
                    if (jaggArray[row].Length == jaggArray[row - 1].Length)
                    {
                        for (int col = 0; col < jaggArray[row].Length; col++)
                        {
                            jaggArray[row - 1][col] *= 2; 
                            jaggArray[row][col] *= 2; 
                        }
                    }
                    else
                    {
                        for (int col = 0; col < jaggArray[row - 1].Length; col++)
                            jaggArray[row - 1][col] /= 2.0;
                        for (int col = 0; col < jaggArray[row].Length; col++)
                            jaggArray[row][col] /= 2.0;
                    }
                }
            }
            string commandLine = "";
            while((commandLine = Console.ReadLine()) != "End")
            {
                string[] commandParts = commandLine.Split().ToArray();
                string majorCommand = commandParts[0];
                int rowNum = int.Parse(commandParts[1]);
                int colNum = int.Parse(commandParts[2]);
                int valueNum = int.Parse(commandParts[3]);
                bool checkIndex = rowNum >= 0 && rowNum < jaggArray.Length &&
                    colNum >= 0 && colNum < jaggArray[rowNum].Length;
                if (majorCommand == "Add" && checkIndex)
                {
                    jaggArray[rowNum][colNum] += valueNum;
                }
                else if (majorCommand == "Subtract" && checkIndex)
                {
                    jaggArray[rowNum][colNum] -= valueNum;
                }
            }

            // Printing the result Matrix
            for (int row = 0; row < linesNum; row++)
            {
                double[] tempArr = new double[jaggArray[row].Length];
                for (int col = 0; col < jaggArray[row].Length; col++)
                {
                    tempArr[col] = jaggArray[row][col];
                }
                Console.WriteLine(string.Join(" ", tempArr));
            }
        }
    }
}
