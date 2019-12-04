using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/AoC19/Inputs/Day1.txt";

            var lines = File.ReadAllLines(path);

            var total = 0;

            foreach(var line in lines)
            {
                total += GetFuel(Int32.Parse(line));
            }

            Console.WriteLine(total);
            Console.ReadLine();
        }

        static int GetFuel(int total, int count = 0)
        {
            var ans = (total / 3) - 2;

            if (ans <= 0)
                return count;

            count += ans;

            return GetFuel(ans, count);
        }
    }
}
