using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presentsNum = int.Parse(Console.ReadLine());
            int matrixSize = int.Parse(Console.ReadLine());
            string[,] matrixPlaces = new string[matrixSize, matrixSize];
            int[] positionSanta = new int[2];
            int niceKidsNum = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                string[] matrixLine = Console.ReadLine().Split();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrixPlaces[row, col] = matrixLine[col];
                    if (matrixPlaces[row, col] == "S")
                    {
                        positionSanta[0] = row;
                        positionSanta[1] = col;
                    }
                    if (matrixPlaces[row, col] == "V")
                        niceKidsNum++;
                }
            }
            int countNiceKids = niceKidsNum;
            int[] positionSantaNew = positionSanta.ToArray();
            while(presentsNum > 0)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "Christmas morning") break;

                if (commandLine == "left")
                    positionSantaNew[1]--;
                else if (commandLine == "right")
                    positionSantaNew[1]++;
                else if (commandLine == "up")
                    positionSantaNew[0]--;
                else if (commandLine == "down")
                    positionSantaNew[0]++;

                if(IsInsideMatrix(matrixPlaces, positionSantaNew))
                {
                    string getElement = GetElementAt(matrixPlaces, positionSantaNew);
                    if(getElement == "-" || getElement == "X")
                    {
                        ChangeElementAt(matrixPlaces, "S", positionSantaNew);
                        ChangeElementAt(matrixPlaces, "-", positionSanta);
                        positionSanta = positionSantaNew.ToArray();
                    }
                    else if (getElement == "V")
                    {
                        countNiceKids--;
                        presentsNum--;
                        ChangeElementAt(matrixPlaces, "S", positionSantaNew);
                        ChangeElementAt(matrixPlaces, "-", positionSanta);
                        positionSanta = positionSantaNew.ToArray();
                    }
                    else if (getElement == "C")
                    {
                        ChangeElementAt(matrixPlaces, "S", positionSantaNew);
                        ChangeElementAt(matrixPlaces, "-", positionSanta);
                        positionSanta = positionSantaNew.ToArray();
                        List<int[]> aroundFour = GetCrossLocatioAround(matrixPlaces, positionSanta);
                        bool flagEnd = false;
                        for (int i = 0; i < aroundFour.Count; i++)
                        {
                            int[] readLocation = aroundFour[i];
                            if (GetElementAt(matrixPlaces, readLocation) == "V")
                            {
                                countNiceKids--;
                                presentsNum--;
                            }
                            else if (GetElementAt(matrixPlaces, readLocation) == "X")
                                presentsNum--;

                            if (presentsNum <= 0)
                            {
                                flagEnd = true;
                                ChangeElementAt(matrixPlaces, "-", readLocation);
                                break;
                            }
                            ChangeElementAt(matrixPlaces, "-", readLocation);
                        }
                        if (flagEnd) break;
                    }
                }
            }
            if(presentsNum <= 0)
                Console.WriteLine("Santa ran out of presents!");

            PrintMatrix(matrixPlaces);
            if(countNiceKids <= 0)
                Console.WriteLine($"Good job, Santa! {niceKidsNum} happy nice kid/s.");
            else
                Console.WriteLine($"No presents for {countNiceKids} nice kid/s.");
        }

        static bool IsInsideMatrix<T>(T[,] inpMatrix, int[] location)
        {
            int rows = inpMatrix.GetLength(0);
            int cols = inpMatrix.GetLength(1);
            return (location[0] >= 0 && location[0] < rows && location[1] >= 0 && location[1] < cols);
        }

        public static T GetElementAt<T>(T[,] inputMatrix, int[] location)
        {
            T element = default;
            if (IsInsideMatrix(inputMatrix, location))
                element = inputMatrix[location[0], location[1]];
            return element;
        }

        public static void ChangeElementAt<T>(T[,] inputMatrix, T theChange, int[] location)
        {
            if (IsInsideMatrix(inputMatrix, location))
                inputMatrix[location[0], location[1]] = theChange;
        }

        public static List<int[]> GetCrossLocatioAround<T>(T[,] inputMatrix, int[] location)
        {
            List<int[]> locationList = new List<int[]>();
            int[,] crossLocations = new int[,] { { 0, -1 }, { 0, 1 }, { -1, 0 }, { 1, 0 } };
            for (int row = 0; row < crossLocations.GetLength(0); row++)
            {
                int[] newLocation = location.ToArray();
                newLocation[0] += crossLocations[row, 0];
                newLocation[1] += crossLocations[row, 1];
                if (IsInsideMatrix(inputMatrix, newLocation))
                {
                    locationList.Add(newLocation);
                }
            }
            return locationList;
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
