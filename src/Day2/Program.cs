using Common;
using System;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            int noun = 0;
            int verb = 0;
            int expected = 19690720;

            OpMachine opMachine = new OpMachine();

            for (var n = 0; n < 100; n++)
            {
                for (var v = 0; v < 100; v++)
                {
                    var result = opMachine.Run(n, v);
                    if (result == expected)
                    {
                        var output = (100 * n) + v;
                        Output.OutputAndWait($"Output: {output}");
                        Environment.Exit(0);
                    }
                    opMachine.Reset();
                }
            }

            Output.OutputAndWait($"Did not find required value");
            Environment.Exit(0);
        }
    }

    class OpMachine
    {
        public int[] OpCodes { get; set; }

        static int[] ValidOpCodes = new[] { 1, 2, 99 };

        public OpMachine()
        {
            Reset();
        }

        public void Reset()
        {
            OpCodes = FileReader.ReadAllSplitByCommaToInt("Day2");
        }

        public int Run(int noun, int verb)
        {
            OpCodes[1] = noun;
            OpCodes[2] = verb;

            for (var index = 0; index < OpCodes.Length; index += 4)
            {
                var code = OpCodes[index];
                switch(code)
                {
                    case 1:
                        Add(index);
                        break;
                    case 2:
                        Multiply(index);
                        break;
                    case 99:
                        return OpCodes[0];
                    default:
                        throw new InvalidOperationException("invalid opcode");
                }
            }

            throw new InvalidOperationException("terminator not found");
        }

        void Add(int index)
        {
            var toSet = OpCodes[index + 3];
            OpCodes[toSet] = OpCodes[OpCodes[index + 1]] + OpCodes[OpCodes[index + 2]];
        }

        void Multiply(int index)
        {
            var toSet = OpCodes[index + 3];
            OpCodes[toSet] = OpCodes[OpCodes[index + 1]] * OpCodes[OpCodes[index + 2]];
        }
    }
}
