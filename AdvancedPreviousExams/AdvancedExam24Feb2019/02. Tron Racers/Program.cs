using System;

namespace T02.TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrixField = new char[size, size];
            int[] fLocation = new int[2];
            int[] sLocation = new int[2];
            for (int row = 0; row < size; row++)
            {
                string readLine = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrixField[row, col] = readLine[col];
                    if(matrixField[row,col] == 'f')
                    {
                        fLocation[0] = row;
                        fLocation[1] = col;
                    }
                    if (matrixField[row, col] == 's')
                    {
                        sLocation[0] = row;
                        sLocation[1] = col;
                    }
                }
            }
            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string firstCom = commands[0];
                string secondCom = commands[1];

                if (firstCom == "left")
                    fLocation[1] = (fLocation[1] - 1 + size) % size;
                else if (firstCom == "right")
                    fLocation[1] = (fLocation[1] + 1) % size;
                else if (firstCom == "up")
                    fLocation[0] = (fLocation[0] - 1 + size) % size;
                else if (firstCom == "down")
                    fLocation[0] = (fLocation[0] + 1) % size;

                char getElement = GetElementAt(matrixField, fLocation);
                if (getElement == '*')
                {
                    ChangeElementAt(matrixField, 'f', fLocation);
                }
                else if (getElement == 's')
                {
                    ChangeElementAt(matrixField, 'x', fLocation);
                    PrintMatrix(matrixField);
                    return;
                }

                if (secondCom == "left")
                    sLocation[1] = (sLocation[1] - 1 + size) % size;
                else if (secondCom == "right")
                    sLocation[1] = (sLocation[1] + 1) % size;
                else if (secondCom == "up")
                    sLocation[0] = (sLocation[0] - 1 + size) % size;
                else if (secondCom == "down")
                    sLocation[0] = (sLocation[0] + 1) % size;

                getElement = GetElementAt(matrixField, sLocation);
                if (getElement == '*')
                {
                    ChangeElementAt(matrixField, 's', sLocation);
                }
                else if (getElement == 'f')
                {
                    ChangeElementAt(matrixField, 'x', sLocation);
                    PrintMatrix(matrixField);
                    return;
                }
            }
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
                Console.WriteLine(string.Join("", getLine));
            }
        }

        public static T GetElementAt<T>(T[,] inputMatrix, int[] location)
        {
            return inputMatrix[location[0], location[1]];
        }

        public static void ChangeElementAt<T>(T[,] inputMatrix, T theChange, int[] location)
        {
            inputMatrix[location[0], location[1]] = theChange;
        }
    }
}
