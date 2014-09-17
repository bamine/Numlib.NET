using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class InsertionSorter
    {
        public static void Sort(ref int[] x)
        {
            int n = x.Length - 1;
            int i, j, temp;

            for (i = 1; i <= n; i++)
            {
                temp = x[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (temp < x[j])
                    {
                        x[j + 1] = x[j];
                    }
                    else
                    {
                        break;
                    }
                }
                x[j + 1] = temp;
            }
        }
    }
}
