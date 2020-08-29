using System;
using System.Collections.Generic;

namespace T06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] readSongs = Console.ReadLine().Split(", ");
            Queue<string> songsQueue = new Queue<string>(readSongs);
            while(songsQueue.Count > 0)
            {
                string[] commandParts = Console.ReadLine().Split();
                string majorCommand = commandParts[0];
                if (majorCommand == "Add")
                {
                    string nameSong = string.Join(" ", commandParts);
                    //nameSong = nameSong.Replace("Add ", "").ToString();
                    nameSong = nameSong.Remove(0, 4).ToString();
                    if (songsQueue.Contains(nameSong))
                        Console.WriteLine($"{nameSong} is already contained!");
                    else songsQueue.Enqueue(nameSong);
                }
                else if (majorCommand == "Play")
                {
                    if (songsQueue.Count > 0)
                        songsQueue.Dequeue();
                }
                else if (majorCommand == "Show")
                {
                    if (songsQueue.Count > 0)
                        Console.WriteLine(string.Join(", ", songsQueue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
