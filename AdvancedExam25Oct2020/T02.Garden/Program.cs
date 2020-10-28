using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimension[0];
            int cols = dimension[1];
            int[,] matrixField = new int[rows, cols];
            List<int[]> flowerLocations = new List<int[]>();

            string inpText = "";
            while((inpText = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] locateFlower = inpText.Split(" ").Select(int.Parse).ToArray();
                if (IsInsideMatrix(matrixField, locateFlower))
                {
                    matrixField[locateFlower[0], locateFlower[1]] = 1;
                    flowerLocations.Add(locateFlower);
                }
                else
                    Console.WriteLine("Invalid coordinates.");
            }
            for (int i = 0; i < flowerLocations.Count; i++)
            {
                int[] getLocation = flowerLocations[i];
                for (int col = 0; col < cols; col++)
                {
                    if(col != getLocation[1])
                        matrixField[getLocation[0], col]++;
                }
                for (int row = 0; row < rows; row++)
                {
                    if (row != getLocation[0])
                        matrixField[row, getLocation[1]]++;
                }
            }
            PrintMatrix(matrixField);
        }

        static bool IsInsideMatrix<T>(T[,] inpMatrix, int[] location)
        {
            int rows = inpMatrix.GetLength(0);
            int cols = inpMatrix.GetLength(1);
            return (location[0] >= 0 && location[0] < rows && location[1] >= 0 && location[1] < cols);
        }

        static void PrintMatrix<T>(T[,] inputMatrix)
        {
            int rowsNum = inputMatrix.GetLength(0);
            int colsNum = inputMatrix.GetLength(1);
            for (int row = 0; row < rowsNum; row++)
            {
                T[] getLine = new T[colsNum];
                for (int col = 0; col < colsNum; col++)
                    getLine[col] = inputMatrix[row, col];
                Console.WriteLine(string.Join(" ", getLine));
            }
        }
    }
}
