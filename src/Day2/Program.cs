using Common;
using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            OpMachine opMachine = new OpMachine();
            var result = opMachine.Run();
            Output.OutputAndWait($"Value at position 0: {result}");
        }
    }

    class OpMachine
    {
        public int[] OpCodes { get; set; }

        public OpMachine()
        {
            OpCodes = FileReader.ReadAllSplitByCommaToInt("Day2");
        }

        public int Run()
        {
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
