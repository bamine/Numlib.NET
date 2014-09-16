using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class CombSorter
    {
        private static int NewGap(int gap)
        {
            gap = gap * 10 / 13;
            if (gap == 9 || gap == 10)
                gap = 11;
            if (gap < 1)
                return 1;
            return gap;
        }

        public static void Sort(ref int[] x)
        {
            int gap = x.Length;
            bool swapped;
            do
            {
                swapped = false;
                gap = NewGap(gap);
                for (int i = 0; i < x.Length - gap; i++)
                {
                    if (x[i] > x[i + gap])
                    {
                        int temp = x[i];
                        x[i] = x[i + gap];
                        x[i + gap] = temp;
                        swapped = true;
                    }
                }
            } while (gap>1||swapped);
        }
    }
}
