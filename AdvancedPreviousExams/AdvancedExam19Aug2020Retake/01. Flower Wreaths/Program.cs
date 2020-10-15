using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            int sumRemains = 0;
            int wreathsCounter = 0;
            while(lilies.Count > 0 && roses.Count > 0)
            {
                int liliesPlusRoses = lilies.Pop() + roses.Dequeue();
                if (liliesPlusRoses >= 15)
                {
                    wreathsCounter++;
                }
                else
                {
                    sumRemains += liliesPlusRoses;
                    wreathsCounter += sumRemains / 15;
                    sumRemains %= 15;
                }
                if (wreathsCounter >= 5)
                    break;
            }
            if(wreathsCounter >= 5)
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCounter} wreaths!");
            else
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCounter} wreaths more!");
        }
    }
}
