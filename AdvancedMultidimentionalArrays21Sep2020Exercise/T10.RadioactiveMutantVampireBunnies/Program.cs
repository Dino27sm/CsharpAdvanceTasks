using System;
using System.Collections.Generic;
using System.Linq;

namespace T10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];
            char[,] bunnyMatrix = new char[rows, columns];
            int[] personPosition = { 0, 0 };

            for (int row = 0; row < rows; row++)
            {
                char[] getLine = Console.ReadLine().ToCharArray();
                for (int col = 0; col < columns; col++)
                {
                    bunnyMatrix[row, col] = getLine[col];
                    if (bunnyMatrix[row, col] == 'P')
                    {
                        personPosition[0] = row;
                        personPosition[1] = col;
                    }
                }
            }
            char[] commandLine = Console.ReadLine().ToCharArray();

            // First -> Perform the Player moves
            int[] personNewPosition = personPosition.ToArray();
            for (int i = 0; i < commandLine.Length; i++)
            {
                char command = commandLine[i];
                if(command == 'L')
                    personNewPosition[1] = personPosition[1] - 1;
                else if (command == 'R')
                    personNewPosition[1] = personPosition[1] + 1;
                else if (command == 'U')
                    personNewPosition[0] = personPosition[0] - 1;
                else if (command == 'D')
                    personNewPosition[0] = personPosition[0] + 1;
                if(IsInsideMatrix(bunnyMatrix, personNewPosition))
                {
                    char getElement = GetElementAt(bunnyMatrix, personNewPosition);
                    if(getElement == '.')
                    {
                        ChangeElementAt(bunnyMatrix, 'P', personNewPosition);
                        ChangeElementAt(bunnyMatrix, '.', personPosition);
                        personPosition = personNewPosition.ToArray();
                    }
                    else if (getElement == 'B')
                    {
                        ChangeElementAt(bunnyMatrix, '.', personPosition);
                        personPosition = personNewPosition.ToArray();
                        ProduceBunny(bunnyMatrix);
                        PrintMatrix(bunnyMatrix);
                        Console.WriteLine($"dead: {personPosition[0]} {personPosition[1]}");
                        return;
                    }

                    if (ProduceBunny(bunnyMatrix))
                    {
                        PrintMatrix(bunnyMatrix);
                        Console.WriteLine($"dead: {personPosition[0]} {personPosition[1]}");
                        return;
                    }
                }
                else
                {
                    ChangeElementAt(bunnyMatrix, '.', personPosition);
                    ProduceBunny(bunnyMatrix);
                    PrintMatrix(bunnyMatrix);
                    Console.WriteLine($"won: {personPosition[0]} {personPosition[1]}");
                    return;
                }
            }
        }
        static bool IsInsideMatrix<T>(T[,] inputMatrix, int[] coordinates)
        {
            int rowNum = inputMatrix.GetLength(0);
            int colNum = inputMatrix.GetLength(1);
            int rowCoord = coordinates[0];
            int colCoord = coordinates[1];
            return (rowCoord >= 0 && rowCoord < rowNum && colCoord >= 0 && colCoord < colNum);
        }

        static T GetElementAt<T>(T[,] inputMatrix, int[] coordinates)
            => inputMatrix[coordinates[0], coordinates[1]];

        static T[,] ChangeElementAt<T>(T[,] inputMatrix, T change, int[] coordinates)
        {
            if (IsInsideMatrix(inputMatrix, coordinates))
                inputMatrix[coordinates[0], coordinates[1]] = change;
            return inputMatrix;
        }

        static bool ProduceBunny(char[,] inputMatrix) 
        {
            bool isHitPerson = false;
            List<int[]> bunnyPositions = new List<int[]>();
            int rowNum = inputMatrix.GetLength(0);
            int colNum = inputMatrix.GetLength(1);
            for (int row = 0; row < rowNum; row++)
            {
                for (int col = 0; col < colNum; col++)
                {
                    if (inputMatrix[row, col] == 'B')
                    {
                        bunnyPositions.Add(new int[2]{ row, col});
                    }
                }
            }
            List<int[]> pattern = new List<int[]>();
            pattern.Add(new int[] { 0, -1 });
            pattern.Add(new int[] { 0, 1 });
            pattern.Add(new int[] { -1, 0 });
            pattern.Add(new int[] { 1, 0 });
            for (int i = 0; i < bunnyPositions.Count; i++)
            {
                int[] hereBunny = bunnyPositions[i].ToArray();
                for (int k = 0; k < pattern.Count; k++)
                {
                    int[] newPosition = {hereBunny[0] + pattern[k][0], hereBunny[1] + pattern[k][1] };
                    if (IsInsideMatrix(inputMatrix, newPosition))
                    {
                        if (inputMatrix[newPosition[0], newPosition[1]] == 'P')
                            isHitPerson = true;
                        ChangeElementAt(inputMatrix, 'B', newPosition);
                    }
                }
            }
            return isHitPerson;
        }

        static void PrintMatrix<T>(T[,] matrixPrint)
        {
            int rowNum = matrixPrint.GetLength(0);
            int colNum = matrixPrint.GetLength(1);
            for (int row = 0; row < rowNum; row++)
            {
                T[] outLine = new T[colNum];
                for (int col = 0; col < colNum; col++)
                {
                    outLine[col] = matrixPrint[row, col];
                }
                Console.WriteLine(string.Join("", outLine));
            }
        }
    }
}

