using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    public class OpCodeReader
    {
        public enum OpCode
        {
            Add = 1,
            Multiply = 2,
            Exit = 99
        }

        public List<int> Process(List<int> input)
        {
            var ret = new List<int>(input);

            var hasMoreInput = true;
            var i = 0;
            while (hasMoreInput)
            {
                var opCode = (OpCode)ret[i];
                if (opCode == OpCode.Exit)
                    break;

                var lpos = ret[i + 1];
                var l = ret[lpos];

                var rpos = ret[i + 2];
                var r = ret[rpos];
                var destination = ret[i + 3];

                var value = ExecuteOpCode(opCode, l, r);
                ret[destination] = value;

                i+=4;

                if (i == ret.Count)
                    hasMoreInput = false;
            }

            return ret;
        }

        private int ExecuteOpCode(OpCode op, int l, int r)
        {
            return op switch
            {
                OpCode.Add => (l + r),
                OpCode.Multiply => (l * r),
                _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
            };
        }
    }
}
