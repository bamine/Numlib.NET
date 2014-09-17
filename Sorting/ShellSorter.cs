using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class ShellSorter
    {
        public static void Sort(ref int[] x)
        {
            int i, j, temp;
            int increment = 3;
            while (increment > 0)
            {
                for (i = 0; i < x.Length; i++)
                {
                    j = i;
                    temp = x[i];
                    while (j >= increment && x[j - increment] > temp)
                    {
                        x[j] = x[j - increment];

                    }
                }
            }
        }
    }
}
