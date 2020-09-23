using System;

namespace T02.KnightsHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] readNames = Console.ReadLine().Split(" ");
            Func<string, string> addTitle = getName => "Sir " + getName;
            foreach (string names in readNames)
                Console.WriteLine(addTitle(names));
        }
    }
}
