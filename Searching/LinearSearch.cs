using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class LinearSearch
    {
        public static int Search(int[] x, int valueToFind)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == valueToFind)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
