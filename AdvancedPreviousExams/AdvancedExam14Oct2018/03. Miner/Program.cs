using System;
using System.Linq;

namespace T03.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] matrixField = new string[size, size];
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] minerLocationOld = new int[2];
            int countCoal = 0;
            for (int row = 0; row < size; row++)
            {
                string[] readRow = Console.ReadLine().Split();
                for (int col = 0; col < size; col++)
                {
                    matrixField[row, col] = readRow[col];
                    if (matrixField[row, col] == "s")
                    {
                        minerLocationOld[0] = row;
                        minerLocationOld[1] = col;
                    }
                    if (matrixField[row, col] == "c")
                        countCoal++;
                }
            }
            int[] minerLocationNew = minerLocationOld.ToArray();
            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];
                if (currentCommand == "left")
                    minerLocationNew[1]--;
                else if (currentCommand == "right")
                    minerLocationNew[1]++;
                else if (currentCommand == "up")
                    minerLocationNew[0]--;
                else if (currentCommand == "down")
                    minerLocationNew[0]++;

                if (IsInsideMatrx(matrixField, minerLocationNew))
                {
                    string gotNewElement = GetElementAt(matrixField, minerLocationNew);
                    if (gotNewElement == "*")
                        minerLocationOld = minerLocationNew.ToArray();
                    else if (gotNewElement == "c")
                    {
                        countCoal--;
                        if (countCoal <= 0)
                        {
                            Console.WriteLine($"You collected all coals! ({minerLocationNew[0]}, {minerLocationNew[1]})");
                            return;
                        }
                        ChangeElementAt(matrixField, "*", minerLocationNew);
                        minerLocationOld = minerLocationNew.ToArray();
                    }
                    else if (gotNewElement == "e")
                    {
                        Console.WriteLine($"Game over! ({minerLocationNew[0]}, {minerLocationNew[1]})");
                        return;
                    }
                }
                else
                    minerLocationNew = minerLocationOld.ToArray();
            }
            Console.WriteLine($"{countCoal} coals left. ({minerLocationNew[0]}, {minerLocationNew[1]})");
        }

        public static bool IsInsideMatrx<T>(T[,] inpMatrix, int[] location)
            => (location[0] >= 0 && location[0] < inpMatrix.GetLength(1)
                && location[1] >= 0 && location[1] < inpMatrix.GetLength(0));

        public static T GetElementAt<T>(T[,] inpMatrix, int[] location)
            => inpMatrix[location[0], location[1]];

        public static void ChangeElementAt<T>(T[,] inpMatrix, T theChange, int[] location)
        {
            inpMatrix[location[0], location[1]] = theChange;
        }
    }
}
