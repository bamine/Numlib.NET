using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class BucketSorter
    {
        public static void Sort(ref int[] x)
        {
            if (x == null || x.Length < 1)
                return;
            int maxValue = x[0];
            int minValue = x[0];
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] > maxValue)
                    maxValue = x[i];
                if (x[i] < minValue)
                    minValue = x[i];
            }
            var bucket = new LinkedList<int>[maxValue - minValue + 1];
            for (int i = 0; i < x.Length; i++)
            {
                if (bucket[x[i] - minValue] == null)
                    bucket[x[i] - minValue] = new LinkedList<int>();
                bucket[x[i] - minValue].AddLast(x[i]);
            }
            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != null)
                {
                    var node = bucket[i].First;

                    while (node != null)
                    {
                        x[k] = node.Value;
                        node = node.Next;
                        k++;
                    }
                }
            }
        }
    }
}