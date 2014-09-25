using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitwise
{
    public class Converters
    {
        public static string DecToBinOctOrHex(int number, int baseval)
        {
            int n, bitcounter, bitstoshift, startbit;
            string digit = "0123456789ABCDEF";

            switch (baseval)
            {
                case 2:
                    startbit = 31;
                    bitstoshift = 1;
                    break;
                case 8:
                    startbit = 30;
                    bitstoshift = 3;
                    break;
                case 16:
                    startbit = 28;
                    bitstoshift = 4;
                    break;
                default:
                    startbit = 0;
                    bitstoshift = 0;
                    break;
            }

            var output = new StringBuilder();
            for (bitcounter = startbit, n = number; bitcounter >= 0; bitcounter -= bitstoshift)
            {
                output.Append(digit[(n >> bitcounter) & (baseval - 1)]);
            }
            return output.ToString();
        }

        public static string DecToBinOctOrHex(double number, int baseval)
        {
            int n, bitcounter, bitstoshift, startbit;
            string digit = "0123456789ABCDEF";

            switch (baseval)
            {
                case 2:
                    startbit = 31;
                    bitstoshift = 1;
                    break;
                case 8:
                    startbit = 30;
                    bitstoshift = 3;
                    break;
                case 16:
                    startbit = 28;
                    bitstoshift = 4;
                    break;
                default:
                    startbit = 0;
                    bitstoshift = 0;
                    break;
            }

            var output = new StringBuilder();
            for (bitcounter = startbit, n = (int)Math.Truncate(number); bitcounter >= 0; bitcounter -= bitstoshift)
            {
                output.Append(digit[(n >> bitcounter) & (baseval - 1)]);
            }
            output.Append(".");
            for (int i = 0; i < 12; i++)
            {
                number = (number - Math.Floor(number)) * baseval;
                output.Append(digit[(int)Math.Truncate(number)]);
            }
            return output.ToString();
        }
    }
}
