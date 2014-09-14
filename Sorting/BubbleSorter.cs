using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class BubbleSorter
    {
        static void Sort1(ref int[] x)
        {
            bool exchanges;
            do
            {
                exchanges = false;
                for (int i = 0; i < x.Length - 1; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        exchanges = true;
                    }
                }
            } while (exchanges);
        }

        static void Sort2(ref int[] x)
        {
            for (int pass = 0; pass < x.Length - 1; pass++)
            {
                for (int i = 0; i < x.Length - pass; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                    }
                }
            }
        }

        static void Sort3(ref int[] x)
        {
            bool exchanges;
            int n=x.Length;
            do
            {
                n--;
                exchanges = false;
                for (int i = 0; i < n; i++)
                {
                    int temp = x[i];
                    x[i] = x[i + 1];
                    x[i + 1] = temp;
                    exchanges = true;
                }

            } while (exchanges);
        }

        static void Sort4(ref int[] x)
        {
            int lowerBound = 0;
            int upperBound = x.Length - 1;
            int n = x.Length - 1;

            while (lowerBound <= upperBound)
            {
                int firstExchange = n;
                int lastExchange = -1;
                for (int i = lowerBound; i < upperBound; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;

                        if (i < firstExchange)
                        {
                            firstExchange = i;
                        }
                        lastExchange = i;
                    }
                }

                lowerBound = firstExchange - 1;
                if(lowerBound<0){
                    lowerBound = 0;
                }
                upperBound = lastExchange;
            }
        }
    }
}
