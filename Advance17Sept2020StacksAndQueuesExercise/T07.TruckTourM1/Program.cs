using System;
using System.Collections.Generic;
using System.Linq;

namespace T07.TruckTourM1
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<long> queueDiff = new Queue<long>();
            int numStations = int.Parse(Console.ReadLine());
            for (int i = 0; i < numStations; i++)
            {
                long[] readLine = Console.ReadLine().Split().Select(long.Parse).ToArray();
                queueDiff.Enqueue(readLine[0] - readLine[1]);
            }
            int startIndex = 0;
            for (int i = 0; i < numStations; i++)
            {
                bool flag = true;
                long tempOut = queueDiff.Peek();
                if (tempOut >= 0)
                {
                    long sumDiff = 0;
                    for (int k = 0; k < numStations; k++)
                    {
                        long tempTwo = queueDiff.Dequeue();
                        sumDiff += tempTwo;
                        queueDiff.Enqueue(tempTwo);
                        if(sumDiff < 0)
                            flag = false;
                    }
                    if (flag)
                    {
                        startIndex = i;
                        break;
                    }
                    queueDiff.Enqueue(queueDiff.Dequeue());
                }
                else
                    queueDiff.Enqueue(queueDiff.Dequeue());
            }
            Console.WriteLine(startIndex);
        }
    }
}
