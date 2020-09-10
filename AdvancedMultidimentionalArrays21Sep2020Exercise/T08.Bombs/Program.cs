using System;
using System.Linq;

namespace T08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrixData = new int[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                int[] readLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrixSize; col++)
                    matrixData[row, col] = readLine[col];
            }
            string[] bombLocation = Console.ReadLine().Split().ToArray();
            for (int i = 0; i < bombLocation.Length; i++)
            {
                int[] currentBomb = bombLocation[i].Split(",").Select(int.Parse).ToArray();
                int bombRow = currentBomb[0];
                int bombCol = currentBomb[1];
                int bombValue = matrixData[bombRow, bombCol];
                if(bombValue > 0)
                {
                    int startRow = 0;
                    int startCol = 0;
                    int endRow = matrixSize;
                    int endCol = matrixSize;
                    if (bombRow - 1 > 0) startRow = bombRow - 1;
                    if (bombCol - 1 > 0) startCol = bombCol - 1;
                    if (bombRow + 1 < matrixSize) endRow = bombRow + 2;
                    if (bombCol + 1 < matrixSize) endCol = bombCol + 2;
                    for (int row = startRow; row < endRow; row++)
                    {
                        for (int col = startCol; col < endCol; col++)
                        {
                            if (matrixData[row, col] > 0)
                                matrixData[row, col] -= bombValue;
                        }
                    }
                }
            }
            int aliveNum = 0;
            int aliveSum = 0;
            foreach (int matrixElement in matrixData)
            {
                if(matrixElement > 0)
                {
                    aliveNum++;
                    aliveSum += matrixElement;
                }
            }
            Console.WriteLine($"Alive cells: {aliveNum}");
            Console.WriteLine($"Sum: {aliveSum}");
            for (int row = 0; row < matrixSize; row++)
            {
                int[] printLine = new int[matrixSize];
                for (int col = 0; col < matrixSize; col++)
                    printLine[col] = matrixData[row, col];
                Console.WriteLine(string.Join(" ", printLine));
            }
        }
    }
}
