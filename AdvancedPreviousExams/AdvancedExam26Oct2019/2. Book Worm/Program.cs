using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T02.BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialString = Console.ReadLine();
            int size = int.Parse(Console.ReadLine());
            char[,] matrixField = new char[size, size];
            int[] oldLocation = new int[2];
            for (int row = 0; row < size; row++)
            {
                string inpLine = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrixField[row, col] = inpLine[col];
                    if(matrixField[row, col] == 'P')
                    {
                        oldLocation[0] = row;
                        oldLocation[1] = col;
                    }
                }
            }
            int[] newLocation = oldLocation.ToArray();
            StringBuilder sbText = new StringBuilder(initialString);
            string command = "";
            while((command = Console.ReadLine()) != "end")
            {
                if (command == "left")
                    newLocation[1]--;
                else if (command == "right")
                    newLocation[1]++;
                else if (command == "up")
                    newLocation[0]--;
                else if (command == "down")
                    newLocation[0]++;

                if(IsInsideMatrix(matrixField, newLocation))
                {
                    char getElement = GetElementAt(matrixField, newLocation);
                    if (char.IsLetter(getElement) && getElement != 'P')
                        sbText.Append(getElement);
                    ChangeElementAt(matrixField, '-', oldLocation);
                    ChangeElementAt(matrixField, 'P', newLocation);
                    oldLocation = newLocation.ToArray();
                }
                else
                {
                    if (sbText.Length > 0)
                        sbText.Remove(sbText.Length - 1, 1);
                    newLocation = oldLocation.ToArray();
                }
            }
            Console.WriteLine(string.Join("", sbText.ToString()));
            PrintMatrix(matrixField);
        }

        static bool IsInsideMatrix<T>(T[,] inpMatrix, int[] location)
        {
            int rows = inpMatrix.GetLength(0);
            int cols = inpMatrix.GetLength(1);
            return (location[0] >= 0 && location[0] < rows && location[1] >= 0 && location[1] < cols);
        }

        public static T GetElementAt<T>(T[,] inputMatrix, int[] location)
            => inputMatrix[location[0], location[1]];

        public static void ChangeElementAt<T>(T[,] inputMatrix, T theChange, int[] location)
        {
            if (IsInsideMatrix(inputMatrix, location))
                inputMatrix[location[0], location[1]] = theChange;
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
    }
}
