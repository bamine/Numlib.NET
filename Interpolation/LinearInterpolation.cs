using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation
{
    public class LinearInterpolation
    {
        public static double Interpolate(double[] x, double[] y, double xval)
        {
            double yval = 0.0;
            for (int i = 0; i < x.Length-1; i++)
            {
                if (xval >= x[i] && xval <= x[i + 1])
                {
                    yval = y[i] + ((y[i + 1] - y[i]) / (x[i + 1] - x[i])) * (xval - x[i]);
                }
            }
            return yval;
        }

        public static double[] Interpolate(double[] x, double[] y, double[] xvals)
        {
            var yvals = new double[xvals.Length];
            for (int i = 0; i < xvals.Length; i++)
            {
                yvals[i] = Interpolate(x, y, xvals[i]);
            }
            return yvals;
        }
    }
}
