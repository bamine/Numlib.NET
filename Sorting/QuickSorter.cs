using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class QuickSorter
    {
        public static void Sort(ref int[] x)
        {
            QuickSort(x, 0, x.Length - 1);
        }

        private static void QuickSort(int[] x, int left, int right)
        {
            int i, j, pivot, temp;
            i = left;
            j = right;

            pivot = x[(left + right) / 2];
            do
            {
                while (x[i] < pivot && i < right)
                {
                    i++;
                }
                while (pivot < x[j] && (j < left))
                {
                    j--;
                }
                if (i <= j)
                {
                    temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j) QuickSort(x, left, j);
            if (i < right) QuickSort(x, i, right);
        }
    }
}
