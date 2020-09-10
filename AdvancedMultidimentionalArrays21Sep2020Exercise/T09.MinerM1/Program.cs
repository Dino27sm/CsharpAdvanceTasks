using System;
using System.Linq;

namespace T09.MinerM1
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();
            string[,] matrixData = new string[dimension, dimension];
            for (int row = 0; row < dimension; row++)
            {
                string[] readLine = Console.ReadLine().Split();
                for (int col = 0; col < dimension; col++)
                    matrixData[row, col] = readLine[col];
            }
            int numCoal = matrixData.Cast<string>().Count(x => x == "c");
            int minerRow = 0;
            int minerCol = 0;
            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension; col++)
                {
                    if (matrixData[row, col] == "s")
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                }
            }
            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];
                if (currentCommand == "left")
                {
                    if (minerCol - 1 >= 0)
                    {
                        minerCol--;
                        if (MinerLocation(matrixData, ref minerRow, ref minerCol, ref numCoal))
                            return;
                    }
                }
                else if (currentCommand == "right")
                {
                    if (minerCol + 1 < dimension)
                    {
                        minerCol++;
                        if (MinerLocation(matrixData, ref minerRow, ref minerCol, ref numCoal))
                            return;
                    }
                }
                else if (currentCommand == "up")
                {
                    if (minerRow - 1 >= 0)
                    {
                        minerRow--;
                        if (MinerLocation(matrixData, ref minerRow, ref minerCol, ref numCoal))
                            return;
                    }
                }
                else if (currentCommand == "down")
                {
                    if (minerRow + 1 < dimension)
                    {
                        minerRow++;
                        if (MinerLocation(matrixData, ref minerRow, ref minerCol, ref numCoal))
                            return;
                    }
                }
            }
            Console.WriteLine($"{numCoal} coals left. ({minerRow}, {minerCol})");
        }

        static bool MinerLocation(string[,] matrixData, ref int minerRow, ref int minerCol, ref int numCoal)
        {
            bool flag = false;
            if (matrixData[minerRow, minerCol] == "e")
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                flag = true;
            }
            else if (matrixData[minerRow, minerCol] == "c")
            {
                numCoal--;
                matrixData[minerRow, minerCol] = "*";
                if (numCoal == 0)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    flag = true;
                }
            }
            return flag;
        }
    }
}
