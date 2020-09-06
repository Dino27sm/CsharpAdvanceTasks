using System;
using System.Linq;

namespace T03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rowNum = dimension[0];
            int colNum = dimension[1];
            int[,] matrixData = new int[rowNum, colNum];
            for (int row = 0; row < rowNum; row++)
            {
                int[] readLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < colNum; col++)
                {
                    matrixData[row, col] = readLine[col];
                }
            }
            int maxSum = int.MinValue;
            int[] maxIndex = { 0, 0 };
            for (int row = 0; row < rowNum - 2; row++)
            {
                for (int col = 0; col < colNum - 2; col++)
                {
                    int tempSum = 0;
                    for (int rowIn = 0; rowIn < 3; rowIn++)
                    {
                        for (int colIn = 0; colIn < 3; colIn++)
                            tempSum += matrixData[row + rowIn, col + colIn];
                    }
                    if(maxSum < tempSum)
                    {
                        maxSum = tempSum;
                        maxIndex[0] = row;
                        maxIndex[1] = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < 3; row++)
            {
                int[] getLine = new int[3];
                for (int col = 0; col < 3; col++)
                    getLine[col] = matrixData[maxIndex[0] + row, maxIndex[1] + col];
                Console.WriteLine(string.Join(" ", getLine));
            }
        }
    }
}
