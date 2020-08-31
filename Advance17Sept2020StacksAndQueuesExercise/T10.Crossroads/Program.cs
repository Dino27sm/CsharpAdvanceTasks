using System;
using System.Collections.Generic;
using System.Linq;

namespace T10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> carQueue = new Queue<string>();
            int countCars = 0;
            int greenTime = int.Parse(Console.ReadLine());
            int yellowTime = int.Parse(Console.ReadLine());
            string carName = "";
            while ((carName = Console.ReadLine()) != "END")
            {
                if (carName == "green")
                {
                    int greenLeft = greenTime;
                    while (carQueue.Any() && greenLeft > 0)
                    {
                        string carToPass = carQueue.Peek();
                        if (carToPass.Length <= greenLeft)
                        {
                            carQueue.Dequeue();
                            greenLeft -= carToPass.Length;
                            countCars++;
                        }
                        else
                        {
                            int carPart = carToPass.Length - greenLeft;
                            if (carPart <= yellowTime)
                            {
                                carQueue.Dequeue();
                                countCars++;
                                break;
                            }
                            else
                            {
                                int indexHit = greenLeft + yellowTime;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{carToPass} was hit at {carToPass[indexHit]}.");
                                return;
                            }
                        }
                    }
                }
                else carQueue.Enqueue(carName);
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{countCars} total cars passed the crossroads.");
        }
    }
}
