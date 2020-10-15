namespace Snake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] snakeMatrix = new char[matrixSize, matrixSize];
            int[] snakePosition = new int[2];
            for (int line = 0; line < matrixSize; line++)
            {
                char[] matrixLine = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    snakeMatrix[line, col] = matrixLine[col];
                    if (snakeMatrix[line, col] == 'S')
                    {
                        snakePosition[0] = line;
                        snakePosition[1] = col;
                    }
                }
            }
            int foodCounter = 0;
            while (true)
            {
                int[] snakeNewPosition = {snakePosition[0], snakePosition[1] };
                string commandLine = Console.ReadLine();
                if (commandLine == "left")
                    snakeNewPosition[1]--;
                else if (commandLine == "right")
                    snakeNewPosition[1]++;
                else if (commandLine == "up")
                    snakeNewPosition[0]--;
                else if (commandLine == "down")
                    snakeNewPosition[0]++;
                
                if (IsInsideMatrix(snakeMatrix, snakeNewPosition))
                {
                    char elementAtNewPosition = GetElementAt(snakeMatrix, snakeNewPosition);
                    if(elementAtNewPosition == '.' || elementAtNewPosition == '-')
                    {
                        snakeMatrix[snakePosition[0], snakePosition[1]] = '.';
                        snakeMatrix[snakeNewPosition[0], snakeNewPosition[1]] = 'S';
                        snakePosition = snakeNewPosition.ToArray();
                    }
                    else if (elementAtNewPosition == '*')
                    {
                        snakeMatrix[snakePosition[0], snakePosition[1]] = '.';
                        snakeMatrix[snakeNewPosition[0], snakeNewPosition[1]] = 'S';
                        snakePosition = snakeNewPosition.ToArray();
                        foodCounter++;
                        if(foodCounter >= 10)
                        {
                            Console.WriteLine("You won! You fed the snake.");
                            Console.WriteLine($"Food eaten: {foodCounter}");
                            break;
                        }
                    }
                    else if (elementAtNewPosition == 'B')
                    {
                        snakeMatrix[snakePosition[0], snakePosition[1]] = '.';
                        snakeMatrix[snakeNewPosition[0], snakeNewPosition[1]] = '.';
                        for (int line = 0; line < matrixSize; line++)
                        {
                            for (int col = 0; col < matrixSize; col++)
                            {
                                if(snakeMatrix[line, col] == 'B')
                                {
                                    snakePosition[0] = line;
                                    snakePosition[1] = col;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Food eaten: {foodCounter}");
                    snakeMatrix[snakePosition[0], snakePosition[1]] = '.';
                    break;
                }
            }
            PrintMatrix(snakeMatrix);
        }

        public static void PrintMatrix<T>(T[,] inputMatrix)
        {
            int matrixSize = inputMatrix.GetLength(0);
            for (int line = 0; line < matrixSize; line++)
            {
                T[] matrixLine = new T[matrixSize];
                for (int col = 0; col < matrixSize; col++)
                {
                    matrixLine[col] = inputMatrix[line, col];
                }
                Console.WriteLine(string.Join("", matrixLine));
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
            if(IsInsideMatrix(inputMatrix, coordinates))
            {
                element = inputMatrix[coordinates[0], coordinates[1]];
            }
            return element;
        }
    }
}
