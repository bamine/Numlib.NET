using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class InterpolationSearcher
    {
        public static int Search(int[] x, int searchValue)
        {
            int low = 0;
            int mid;
            int high = x.Length - 1;

            while (x[low] < searchValue && x[high] >= searchValue)
            {
                mid = low + ((searchValue - low) * (high - low)) / (x[high] - x[low]);
                if (x[mid] < searchValue)
                {
                    low = mid + 1;
                }
                else if (x[mid] > searchValue)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            if (x[low] == searchValue)
            {
                return low;
            }
            else
            {
                return -1;
            }
        }
    }
}
