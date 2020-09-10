using System;
using System.Linq;

namespace T09.Miner
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
                    if(minerCol - 1 >= 0)
                    {
                        minerCol--;
                        if(matrixData[minerRow, minerCol] == "e")
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else if (matrixData[minerRow, minerCol] == "c")
                        {
                            numCoal--;
                            matrixData[minerRow, minerCol] = "*";
                            if (numCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                    }
                }
                else if (currentCommand == "right")
                {
                    if (minerCol + 1 < dimension)
                    {
                        minerCol++;
                        if (matrixData[minerRow, minerCol] == "e")
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else if (matrixData[minerRow, minerCol] == "c")
                        {
                            numCoal--;
                            matrixData[minerRow, minerCol] = "*";
                            if (numCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                    }
                }
                else if (currentCommand == "up")
                {
                    if (minerRow - 1 >= 0)
                    {
                        minerRow--;
                        if (matrixData[minerRow, minerCol] == "e")
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else if (matrixData[minerRow, minerCol] == "c")
                        {
                            numCoal--;
                            matrixData[minerRow, minerCol] = "*";
                            if (numCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                    }
                }
                else if (currentCommand == "down")
                {
                    if (minerRow + 1 < dimension)
                    {
                        minerRow++;
                        if (matrixData[minerRow, minerCol] == "e")
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                        else if (matrixData[minerRow, minerCol] == "c")
                        {
                            numCoal--;
                            matrixData[minerRow, minerCol] = "*";
                            if (numCoal == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"{numCoal} coals left. ({minerRow}, {minerCol})");
        }
    }
}
