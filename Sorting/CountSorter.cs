using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class CountSorter
    {
        public static void Sort(ref int[] x)
        {
            int i = 0;
            int k = FindMax(x);
            var output = new int[x.Length];
            int[] temp = new int[k + 1];
            for (i = 0; i < temp.Length; i++)
            {
                temp[i] = 0;
            }
            for (i = 0; i < x.Length; i++)
            {
                temp[x[i]]++;
            }
            for (i = 1; i < k + 1; i++)
            {
                temp[i] += temp[i - 1];
            }
            for (i = x.Length - 1; i >= 0; i--)
            {
                output[temp[x[i]] - 1] = x[i];
                temp[x[i]] -= 1;
            }
            Array.Copy(output, x, x.Length);
        }

        private static int FindMax(int[] x)
        {
            int temp=x[0];
            int max=0;
            for (int i = 1; i < x.Length; i++)
            {
                if (x[i] > temp)
                {
                    temp = x[i];
                    max = i;
                }
            }
            return max;
        }
    }
}
