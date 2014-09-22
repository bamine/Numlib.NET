using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class BinarySearcher
    {
        public static int Search(int[] x, int searchValue)
        {
            int left = 0;
            int right = x.Length;
            return binarySearch(x, searchValue, left, right);
        }

        private static int binarySearch(int[] x, int searchValue, int left, int right)
        {
            if (right < left)
                return -1;
            int mid = (left + right) / 2;
            if (searchValue > x[mid])
            {
                return binarySearch(x, searchValue, mid + 1, right);
            }
            else if (searchValue < x[mid])
            {
                return binarySearch(x, searchValue, left, mid - 1);
            }
            else
                return mid;
        }
    }
}
