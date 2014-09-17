using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class GnomeSorter
    {
        public static void Sort(ref int[] x)
        {
            int i = 0;
            while (i < x.Length)
            {
                if (i == 0 || x[i - 1] <= x[i]) i++;
                else
                {
                    int temp = x[i];
                    x[i] = x[i - 1];
                    x[i - 1] = temp;
                    i--;
                }
            }
        }
    }
}
