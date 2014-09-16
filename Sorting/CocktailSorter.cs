using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class CocktailSorter
    {
        public static void Sort(ref int[] x)
        {
            for (int k = 0; k < x.Length - 1; k++)
            {
                bool swapped = false;
                for (int i = k; i > 0; i--)
                {
                    if (x[i] < x[i - 1])
                    {
                        var temp = x[i];
                        x[i] = x[i - 1];
                        x[i - 1] = temp;
                        swapped = true;
                    }
                }
                for (int i = 0; i < k; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }
    }
}
