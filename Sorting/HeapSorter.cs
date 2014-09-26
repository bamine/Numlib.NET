using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class HeapSorter
    {
        public static void Sort(ref int[] x)
        {
            int i;
            int temp;
            int n = x.Length;
            for (i = (n / 2) - 1; i >= 0; i--)
            {
                siftDown(ref x, i, n);
            }
            for (i = n - 1; i >= 1; i--)
            {
                temp = x[0];
                x[0] = x[i];
                x[i] = temp;
                siftDown(ref x, 0, i - 1);
            }
        }

        private static void siftDown(ref int[] x, int root, int bottom)
        {
            bool done = false;
            int maxChild;
            int temp;
            while (root * 2 <= bottom && !done)
            {
                if (root * 2 == bottom)
                {
                    maxChild = root * 2;
                }
                else if (x[root * 2] > x[root * 2 + 1])
                {
                    maxChild = root * 2;
                }
                else
                {
                    maxChild = root * 2 + 1;
                }
                if (x[root] < x[maxChild])
                {
                    temp = x[root];
                    x[root] = x[maxChild];
                    x[maxChild] = temp;
                    root = maxChild;
                }
                else
                {
                    done = true;
                }

            }
        }
    }
}
