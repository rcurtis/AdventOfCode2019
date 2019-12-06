using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    public class PasswordValidator
    {
        public bool IsValid(int input)
        {
            var ins = input.ToString();
            return HasSixDigits(ins) && HasMatchingPair(ins) && DoesntDecrease(ins);
        }

        private bool HasSixDigits(string input)
        {
            return input.Length == 6;
        }

        private bool HasMatchingPair(string ins)
        {
            var i = 0;
            while (i < ins.Length)
            {
                var candidate = ins[i++];
                var count = 1;

                while (i < ins.Length && ins[i] == candidate)
                {
                    count++;
                    i++;
                }

                if (count == 2)
                    return true;
            }

            return false;
        }

        private bool DoesntDecrease(string ins)
        {
            var last = int.Parse(ins[0].ToString());
            for (int i = 1; i < ins.Length; i++)
            {
                var current = int.Parse(ins[i].ToString());
                if (current < last)
                    return false;
                last = current;
            }

            return true;
        }
    }
}
