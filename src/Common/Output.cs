using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class Output
    {
        public static void OutputAndWait(string display)
        {
            Console.WriteLine(display);
            Console.ReadLine();
        }
    }
}
