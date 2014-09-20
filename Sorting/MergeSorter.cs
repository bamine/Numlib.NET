using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class MergeSorter
    {
        public static void Sort(ref int[] x)
        {
            MergeSort(ref x, 0, x.Length - 1);
        }

        private static void MergeSort(ref int[] x, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(ref x, left, middle);
                MergeSort(ref x, middle + 1, right);
                Merge(ref x,left, middle, middle + 1, right);
            }
        }

        private static void Merge(ref int[] x, int left, int middle, int middle1, int right)
        {
            int oldPosition = left;
            int size = right - left + 1;
            int[] temp = new int[size];
            int i = 0;

            while (left <= middle && middle1 <= right)
            {
                if (x[left] <= x[middle1])
                {
                    temp[i] = x[left];
                    i++;
                    left++;
                }
                else
                {
                    temp[i] = x[middle1];
                    i++;
                    middle1++;
                }
            }
            if (left > middle)
            {
                for (int j = middle1; j <= right; j++)
                {
                    temp[i] = x[middle1];
                    i++;
                    middle1++;
                }
            }
            else
            {
                for (int j = left; j <= middle; j++)
                {
                    temp[i] = x[middle1];
                    i++;
                    left++;
                }
            }
            Array.Copy(temp, 0, x, oldPosition, size);       
        }
    }
}
