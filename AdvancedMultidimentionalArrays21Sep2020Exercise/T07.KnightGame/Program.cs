using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace T07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> locationPoints = new List<int[]>();
            int matrixSize = int.Parse(Console.ReadLine());
            for (int row = 0; row < matrixSize; row++)
            {
                char[] readLine = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    if (readLine[col] == 'K')
                    {
                        int[] knightPosition = { row, col };
                        locationPoints.Add(knightPosition);
                    }
                }
            }
            int coutDeleted = 0;
            while (true)
            {
                int maxCounter = 0;
                int indexMax = 0;
                for (int i = 0; i < locationPoints.Count; i++)
                {
                    int tempCounter = 0;
                    for (int k = 0; k < locationPoints.Count; k++)
                    {
                        int rowDiff = Math.Abs(locationPoints[i][0] - locationPoints[k][0]);
                        int colDiff = Math.Abs(locationPoints[i][1] - locationPoints[k][1]);
                        if ((rowDiff == 1 && colDiff == 2) || (rowDiff == 2 && colDiff == 1))
                        {
                            tempCounter++;
                        }
                    }
                    if (maxCounter < tempCounter)
                    {
                        maxCounter = tempCounter;
                        indexMax = i;
                    }
                }
                if (maxCounter > 0)
                {
                    locationPoints.RemoveAt(indexMax);
                    coutDeleted++;
                }
                else break;
            }
            Console.WriteLine(coutDeleted);
        }
    }
}
