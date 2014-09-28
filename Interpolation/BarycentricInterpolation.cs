using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation
{
    public class BarycentricInterpolation
    {
        public static Func<double, double> BuildBarycentricInterpolator(double[] x, double[] y)
        {
            Func<double, double> interpolator = xval =>
            {
                double product;
                double delta;
                double bc1=0;
                double bc2=0;

                int size = x.Length;
                var weights = new double[size];
                for (int i = 0; i < size; i++)
                {
                    product = 1;
                    for (int j = 0; j < size; j++)
                    {
                        if (i != j)
                        {
                            product *= (x[i] - x[j]);
                            weights[i] = 1.0 / product;
                        }
                    }
                }

                for (int i = 0; i < size; i++)
                {
                    delta = weights[i] / (xval - x[i]);
                    bc1 += y[i] * delta;
                    bc2 = delta;
                }
                return bc1 / bc2;
            };

            return interpolator;
        }
    }
}
