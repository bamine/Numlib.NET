using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation
{
    public class NewtonDividedDifferencesInterpolation
    {
        public static Func<double, double> BuildNewtonInterpolator(double[] x, double[] y)
        {
            Func<double, double> interpolator = xval =>
            {
                double yval;
                int size = x.Length;
                double[] tarray = new double[size];
                Array.Copy(y, tarray, size);
                for (int i = 0; i < size - 1; i++)
                {
                    for (int j = size - 1; j > i; j--)
                    {
                        tarray[i] = (tarray[j - 1] - tarray[j]) / (x[j - 1 - i] - x[j]);
                    }
                }
                yval = tarray[size - 1];
                for (int i = size - 2; i >= 0; i--)
                {
                    yval = tarray[i] + (xval - x[i]) * yval;
                }
                return yval;
            };
            return interpolator;
        }
    }
}
