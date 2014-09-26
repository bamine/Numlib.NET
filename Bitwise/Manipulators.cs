using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitwise
{
    public class Manipulators
    {
        public static string DiplayBits(int value, int nBitsToDisplay)
        {
            int mask = 1 << nBitsToDisplay - 1;
            var output = new StringBuilder();

            for (int bitcounter = 0; bitcounter <= nBitsToDisplay; bitcounter++)
            {
                output.Append((value & value) == 0 ? "0" : "1");
                value <<= 1;
                if (bitcounter % 8 == 0)
                    output.Append(" ");
            }
            return output.ToString();
        }

        public static int SetBits(int value, int mask)
        {
            return value | mask;
        }

        public static int ClearBits(int value, int mask)
        {
            return value & ~mask;
        }

        public static int SetBitsExcept(int value, int mask)
        {
            return value | ~mask;
        }

        public static int ClearBitsExcept(int value, int mask)
        {
            return value & mask;
        }

        public static bool IsAnyBitSet(int value, int mask)
        {
            return (value & mask) != 0;
        }

        public static bool AreAllBitsSet(int value, int mask)
        {
            return (value & mask) == mask;
        }

        public static bool AreAllBitsClear(int value, int mask)
        {
            return (value & mask) == 0;
        }
        public static int BitFlip(int value, int n)
        {
            return ((value) ^ (1 << (n)));
        }

        public static void BitToggle(int value, int mask)
        {
            mask ^= value;
        }

        public static int SetBitByPos(int value, int bitNumber)
        {
            return value | (1 << bitNumber);
        }

        public static int ClearBitByPos(int value, int bitNumber)
        {
            return value & ~(1 << bitNumber);
        }

        public static bool IsBitSetByPos(int value, int bitNumber)
        {
            return (value & (1 << bitNumber)) != 0;
        }

        public static bool IsBitClearByPos(int value, int bitNumber)
        {
            return !IsBitSetByPos(value, bitNumber);
        }
        public static int SetBits(int value, int mask, int bSet)
        {
            return bSet == 0 ? SetBits(value, mask) : ClearBits(value, mask);
        }

        public static int SetClearBits(int value, int add, int remove)
        {
            return (value | add) & ~remove;
        }

        public static int OnesComplement(int value)
        {
            return ~value;
        }

        public static int TwosComplement(int value)
        {
            return ~value + 1;
        }




    }
}
