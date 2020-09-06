using System;
using System.Linq;

namespace T04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int numRows = dimension[0];
            int numCols = dimension[1];
            string[,] matrixData = new string[numRows, numCols];
            for (int row = 0; row < numRows; row++)
            {
                string[] readLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < numCols; col++)
                    matrixData[row, col] = readLine[col];
            }
            string commandLine = "";
            while((commandLine = Console.ReadLine()) != "END")
            {
                bool flagOK = true;
                string[] commandParts = commandLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (commandParts[0] == "swap" && commandParts.Length == 5)
                {
                    int rowOne = int.Parse(commandParts[1]);
                    int colOne = int.Parse(commandParts[2]);
                    int rowTwo = int.Parse(commandParts[3]);
                    int colTwo = int.Parse(commandParts[4]);
                    bool checkIndex = rowOne >= 0 && rowOne < numRows && colOne >= 0 && colOne < numCols &&
                        rowTwo >= 0 && rowTwo < numRows && colTwo >= 0 && colTwo < numCols;
                    if (checkIndex)
                    {
                        string tempBox = matrixData[rowOne, colOne];
                        matrixData[rowOne, colOne] = matrixData[rowTwo, colTwo];
                        matrixData[rowTwo, colTwo] = tempBox;
                    }
                    else flagOK = false;
                }
                else flagOK = false;

                if(flagOK) 
                    PrintMatrix(matrixData);
                else 
                    Console.WriteLine("Invalid input!");
            }
        }

        static void PrintMatrix(string[,] matrixInp)
        {
            int rowsNum = matrixInp.GetLength(0);
            int colsNum = matrixInp.GetLength(1);
            for (int row = 0; row < rowsNum; row++)
            {
                string[] getLine = new string[colsNum];
                for (int col = 0; col < colsNum; col++)
                    getLine[col] = matrixInp[row, col];
                Console.WriteLine(string.Join(" ", getLine));
            }
        }
    }
}
