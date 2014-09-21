using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class RadixSorter
    {
        public static void Sort(ref int[] x, int bits)
        {
            var b = new int[x.Length];
            var oldb = b;

            int rshift = 0;
            for (int mask = ~(-1 << bits); mask != 0; mask <<= bits, rshift += bits)
            {
                var cntarray = new int[1 << bits];
                for (int p = 0; p < x.Length; p++)
                {
                    int key = (x[p] & mask) >> rshift;
                    cntarray[key]++;
                }
                for (int i = 1; i < cntarray.Length; i++)
                {
                    cntarray[i] += cntarray[i - 1];
                }
                for (int p = x.Length - 1; p >= 0; p--)
                {
                    int key = (x[p] & mask) >> rshift;
                    cntarray[key]--;
                    b[cntarray[key]] = x[p];
                }
                int[] temp = b;
                b = x;
                x = temp;
            }
        }
    }
}
