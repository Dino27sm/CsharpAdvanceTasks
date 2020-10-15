using System;
using System.Linq;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] flowerMatrix = new char[matrixSize, matrixSize];
            int[] beePosition = new int[2];
            for (int row = 0; row < matrixSize; row++)
            {
                char[] readRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    flowerMatrix[row, col] = readRow[col];
                    if (flowerMatrix[row, col] == 'B')
                    {
                        beePosition[0] = row;
                        beePosition[1] = col;
                    }
                }
            }
            int pollinateCounter = 0;
            int[] beeNewPosition = beePosition.ToArray();
            bool metBonus = false;
            string readCommand = "";
            while (true)
            {
                if (!metBonus)
                {
                    readCommand = Console.ReadLine();
                }
                metBonus = false;
                if (readCommand == "End")
                    break;
                if (readCommand == "left")
                    beeNewPosition[1]--;
                else if (readCommand == "right")
                    beeNewPosition[1]++;
                else if (readCommand == "up")
                    beeNewPosition[0]--;
                else if (readCommand == "down")
                    beeNewPosition[0]++;

                if (IsInsideMatrix(flowerMatrix, beeNewPosition))
                {
                    char getElement = GetElementAt(flowerMatrix, beeNewPosition);
                    if (getElement == 'O')
                    {
                        metBonus = true;
                        flowerMatrix[beePosition[0], beePosition[1]] = '.';
                        flowerMatrix[beeNewPosition[0], beeNewPosition[1]] = 'B';
                        beePosition = beeNewPosition.ToArray();
                        continue;
                    }
                    else if (getElement == '.')
                    {
                        flowerMatrix[beePosition[0], beePosition[1]] = '.';
                        flowerMatrix[beeNewPosition[0], beeNewPosition[1]] = 'B';
                        beePosition = beeNewPosition.ToArray();
                    }
                    else if (getElement == 'f')
                    {
                        flowerMatrix[beePosition[0], beePosition[1]] = '.';
                        flowerMatrix[beeNewPosition[0], beeNewPosition[1]] = 'B';
                        beePosition = beeNewPosition.ToArray();
                        pollinateCounter++;
                    }
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    flowerMatrix[beePosition[0], beePosition[1]] = '.';
                    break;
                }
            }
            if (pollinateCounter >= 5)
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinateCounter} flowers!");
            else
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinateCounter} flowers more");

            PrintMatrix(flowerMatrix);
        }

        public static void PrintMatrix<T>(T[,] matrixInp)
        {
            int rowsNum = matrixInp.GetLength(0);
            int colsNum = matrixInp.GetLength(1);
            for (int row = 0; row < rowsNum; row++)
            {
                T[] getLine = new T[colsNum];
                for (int col = 0; col < colsNum; col++)
                    getLine[col] = matrixInp[row, col];
                Console.WriteLine(string.Join("", getLine));
            }
        }

        public static bool IsInsideMatrix<T>(T[,] inputMatrix, int[] coordinates)
        {
            int matrixLines = inputMatrix.GetLength(0);
            int matrixColumns = inputMatrix.GetLength(1);
            return (coordinates[0] >= 0 && coordinates[0] < matrixLines && coordinates[1] >= 0
                && coordinates[1] < matrixColumns);
        }

        public static T GetElementAt<T>(T[,] inputMatrix, int[] coordinates)
        {
            T element = default;
            if (IsInsideMatrix(inputMatrix, coordinates))
            {
                element = inputMatrix[coordinates[0], coordinates[1]];
            }
            return element;
        }
    }
}
