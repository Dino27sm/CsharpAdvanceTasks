using System;
using System.Linq;

namespace _02.ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] position = new int[2];
            int matrixSize = int.Parse(Console.ReadLine());
            int numCommands = int.Parse(Console.ReadLine());
            char[,] matrixPlay = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                char[] readLine = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrixPlay[row, col] = readLine[col];
                    if(matrixPlay[row, col] == 'f')
                    {
                        position[0] = row;
                        position[1] = col;
                    }
                }
            }

            bool flagRead = true;
            string command = "";
            for (int i = 0; i < numCommands; i++)
            {
                if (flagRead)
                    command = Console.ReadLine();
                flagRead = true;
                int[] newPosition = position.ToArray();
                if (command == "left")
                    newPosition[1] = (newPosition[1] - 1 + matrixSize) % matrixSize;
                else if (command == "right")
                    newPosition[1] = (newPosition[1] + 1) % matrixSize;
                else if (command == "up")
                    newPosition[0] = (newPosition[0] - 1 + matrixSize) % matrixSize;
                else if (command == "down")
                    newPosition[0] = (newPosition[0] + 1) % matrixSize;

                char getElement = GetElementAt(matrixPlay, newPosition);
                if(getElement == '-')
                {
                    ChangeElementAt(matrixPlay, 'f', newPosition);
                    char whatChar = GetElementAt(matrixPlay, position);
                    if (whatChar != 'B')
                        ChangeElementAt(matrixPlay, '-', position);
                    position = newPosition.ToArray();
                }
                else if (getElement == 'B')
                {
                    ChangeElementAt(matrixPlay, '-', position);
                    position = newPosition.ToArray();
                    flagRead = false;
                    i--;
                    continue;
                }
                else if (getElement == 'T') continue;

                else if (getElement == 'F')
                {
                    ChangeElementAt(matrixPlay, 'f', newPosition);
                    char whatChar = GetElementAt(matrixPlay, position);
                    if(whatChar != 'B')
                        ChangeElementAt(matrixPlay, '-', position);
                    Console.WriteLine("Player won!");
                    PrintMatrix(matrixPlay);
                    return;
                }
            }
            Console.WriteLine("Player lost!");
            PrintMatrix(matrixPlay);
        }

        static T GetElementAt<T>(T[,] inputMatrix, int[] location)
            => inputMatrix[location[0], location[1]];

        static void ChangeElementAt<T>(T[,] inputMatrix, T change, int[] location)
        {
            inputMatrix[location[0], location[1]] = change;
        }

        static void PrintMatrix<T>(T[,] inputMatrix)
        {
            for (int row = 0; row < inputMatrix.GetLength(0); row++)
            {
                T[] currentRow = new T[inputMatrix.GetLength(1)];
                for (int col = 0; col < inputMatrix.GetLength(1); col++)
                    currentRow[col] = inputMatrix[row, col];
                Console.WriteLine(string.Join("", currentRow));
            }
        }
    }
}
