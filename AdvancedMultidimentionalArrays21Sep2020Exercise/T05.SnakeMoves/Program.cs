using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rowsNum = dimentions[0];
            int colsNum = dimentions[1];
            char[] readSnake = Console.ReadLine().ToCharArray();
            Queue<char> queueSnake = new Queue<char>(readSnake);
            char[,] matrixData = new char[rowsNum, colsNum];
            for (int row = 0; row < rowsNum; row++)
            {
                for (int col = 0; col < colsNum; col++)
                {
                    matrixData[row, col] = queueSnake.Peek();
                    queueSnake.Enqueue(queueSnake.Dequeue());
                }
            }
            for (int row = 1; row < rowsNum; row += 2)
            {
                for (int col = 0; col < colsNum / 2; col++)
                {
                    char tempCel = matrixData[row, col];
                    matrixData[row, col] = matrixData[row, colsNum - 1 - col];
                    matrixData[row, colsNum - 1 - col] = tempCel;
                }
            }
            // Print the result Matrix
            for (int row = 0; row < rowsNum; row++)
            {
                char[] matrixLine = new char[colsNum];
                for (int col = 0; col < colsNum; col++)
                    matrixLine[col] = matrixData[row, col];
                Console.WriteLine(string.Join("", matrixLine));
            }
        }
    }
}
