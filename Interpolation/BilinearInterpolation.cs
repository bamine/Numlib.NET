using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation
{
    public class BilinearInterpolation
    {
        public static double Interpolate(double[] x, double[] y, double[,] z, double xval, double yval)
        {
            double zval = 0.0;
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < y.Length; j++)
                {
                    if (xval >= x[i] && xval <= x[i + 1] && yval >= y[i] && yval <= y[i + 1])
                    {
                        zval = ((x[i + 1] - xval) * (y[j + 1] - yval)) / ((x[i + 1] - x[i]) * (y[j + 1] - y[j])) * z[i, j] +
                            ((xval - x[i]) * (y[i + 1] - yval)) / ((x[i + 1] - x[i]) * (y[j + 1] - y[j])) * z[i + 1, j] +
                            ((x[i + 1] - xval) * (yval - y[j])) / ((x[i + 1] - x[i]) * (y[j + 1] - y[j])) * z[i, j + 1] +
                            ((xval - x[i]) * (yval - y[j])) / ((x[i + 1] - x[i]) * (y[j + 1] - y[i])) * z[i + 1, j + 1];
                    }
                }
            }
            return zval;
        }

        public static double[] Interpolate(double[] x, double[] y, double[,] z, double[] xvals, double[] yvals)
        {
            var zvals = new double[xvals.Length];
            for (int i = 0; i < xvals.Length; i++)
            {
                zvals[i] = Interpolate(x, y, z, xvals[i], yvals[i]);
            }
            return zvals;
        }
    }
}
