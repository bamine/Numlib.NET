using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class OddEvenSorter
    {
        public static void Sort(ref int[] x)
        {
            int temp;
            for (int i = 0; i < x.Length / 2; i++)
            {
                for (int j = 0; j < x.Length - 1; j+=2)
                {
                    if (x[j] < x[j + 1])
                    {
                        temp = x[j];
                        x[j] = x[j + 1];
                        x[j + 1] = temp;
                    }
                }

                for (int j = 1; j < x.Length - 1; j+=2)
                {
                    if (x[j] < x[j + 1])
                    {
                        temp = x[j];
                        x[j] = x[j + 1];
                        x[j + 1] = temp;
                    }
                }

            }
        }
    }
}
