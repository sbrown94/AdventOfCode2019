using System;
using System.IO;
using System.Linq;

namespace Common
{
    public static class FileReader
    {
        public static string[] ReadAllLines(string day) => File.ReadAllLines(GetPath(day));

        public static int[] ReadAllSplitByCommaToInt(string day)
        {
            var text = File.ReadAllText(GetPath(day));
            return text.Split(',').Select(x => Int32.Parse(x)).ToArray();
        }

        private static string GetPath(string day)
        {
            return $"../../../../../inputs/{day}.txt";
        }
    }
}
