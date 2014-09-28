using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation
{
    public class LagrangeInterpolation
    {
        public static Func<double, double> BuildLagrangeInterpolator(double[] x, double[] y)
        {
            Func<double, double> interpolator = xval =>
            {
                double yval = 0.0;
                double products = y[0];
                for (int i = 0; i < x.Length; i++)
                {
                    products = y[i];
                    for (int j = 0; j < x.Length; j++)
                    {
                        if (i != j)
                        {
                            products *= (xval - x[j]) / (x[i] - x[j]);
                        }
                    }
                    yval += products;
                }
                return yval;
            };

            return interpolator;
        }
    }
}
