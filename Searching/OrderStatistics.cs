using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class OrderStatistics
    {
        public static int NthLargest(int[] x, int n)
        {
            var tempArray = new int[x.Length];
            x.CopyTo(tempArray, 0);
            Sorting.QuickSorter.Sort(ref tempArray);

            return tempArray[tempArray.Length - n];
        }

        public static int NthLargest2(int[] x, int n)
        {
            int maxIndex;
            int maxValue;
            var tempArray = new int[x.Length];
            x.CopyTo(tempArray, 0);
            for (int i = 0; i < n; i++)
            {
                maxIndex = i;
                maxValue = tempArray[i];
                for (int j = i + 1; j < tempArray.Length; j++)
                {
                    if (tempArray[i] > maxValue)
                    {
                        maxIndex = j;
                        maxValue = tempArray[j];
                    }
                }
                Swap(ref tempArray[i], ref tempArray[maxIndex]);
            }
            return tempArray[n - 1];
        }

        private static void Swap(ref int p1, ref int p2)
        {
            int temp = p1;
            p1 = p2;
            p2 = temp;
        }
    }
}
