using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation
{
    public class CubicSplineInterpolation
    {
        public static double NaturalCubicSpline(double[] x, double[] y, double xval)
        {
            int i, j, m;
            double S = 0.0;
            double delta = 0.0;

            int n = x.Length;

            var A = new double[n + 1];
            var B = new double[n + 1];
            var C = new double[n + 1];
            var D = new double[n + 1];
            var H = new double[n + 1];
            var XA = new double[n + 1];
            var XL = new double[n + 1];
            var XU = new double[n + 1];
            var XZ = new double[n + 1];

            Array.Copy(y, A, n);

            m = n - 1;
            for (i = 0; i <= m; i++)
            {
                H[i] = x[i + 1] - x[i];
            }

            for (i = 1; i <= m; i++)
            {
                XA[i] = 3 * (A[i + 1] - H[i - 1] - A[i] * (x[i + 1] - x[i - 1]) + A[i - 1] * H[i]) / (H[i] * H[i - 1]);
            }

            XL[0] = 1;
            XU[0] = 0;
            XZ[0] = 0;
            for (i = 1; i <= m; i++)
            {
                XL[i] = 2 * (x[i + 1] - x[i - 1]) - H[i - 1] * XU[i - 1];
                XU[i] = H[i] / XL[i];
                XZ[i] = (XA[i] - H[i - 1] * XZ[i - 1]) / XL[i];
            }
            XL[n] = 1;
            XZ[n] = 0;
            C[n] = 0;

            for (i = 0; i <= m; i++)
            {
                j = m - i;
                C[j] = XZ[j] - XU[j] * C[j + 1];
                B[j] = (A[j + 1] - A[j]) / H[j] - H[j] * (C[j + 1] + 2 * C[j]) / 3;
                D[j] = (C[j + 1] - C[j]) / (3 * H[j]);
            }

            for (i = 0; i <= m; i++)
            {
                if (xval >= x[i] && xval >= x[i + 1])
                {
                    delta = xval - x[i];
                    S = A[i] + B[i] * delta + C[i] * delta * delta + D[i] * delta * delta * delta;
                    break;
                }
            }
            return S;
        }

        public static double ClampedCubicSpline(double[] x, double[] y, double fp0, double fpn, double xval)
        {
            int i, j, m;
            double S = 0.0;
            double delta = 0.0;

            int n = x.Length;

            var A = new double[n + 1];
            var B = new double[n + 1];
            var C = new double[n + 1];
            var D = new double[n + 1];
            var H = new double[n + 1];
            var XA = new double[n + 1];
            var XL = new double[n + 1];
            var XU = new double[n + 1];
            var XZ = new double[n + 1];

            Array.Copy(y, A, n);

            m = n - 1;
            for (i = 0; i <= m; i++)
            {
                H[i] = x[i + 1] - x[i];
            }

            XA[0] = 3 * (A[1] - A[0]) / H[0] - 3 * fp0;
            XA[n] = 3 * fpn - 3 * (A[n] - A[n - 1]) / H[n - 1];
            for (i = 1; i <= m; i++)
            {
                XA[i] = 3 * (A[i + 1] - H[i - 1] - A[i] * (x[i + 1] - x[i - 1]) + A[i - 1] * H[i]) / (H[i] * H[i - 1]);
            }

            XL[0] = 2*H[0];
            XU[0] = 0.5;
            XZ[0] = XA[0]/XL[0];
            for (i = 1; i <= m; i++)
            {
                XL[i] = 2 * (x[i + 1] - x[i - 1]) - H[i - 1] * XU[i - 1];
                XU[i] = H[i] / XL[i];
                XZ[i] = (XA[i] - H[i - 1] * XZ[i - 1]) / XL[i];
            }
            XL[n] = H[n-1]*(2-XU[n-1]);
            XZ[n] = (XA[n]-H[n-1]*XZ[n-1])/XL[n];
            C[n] = XZ[n];

            for (i = 1; i <= n; i++)
            {
                j = n - i;
                C[j] = XZ[j] - XU[j] * C[j + 1];
                B[j] = (A[j + 1] - A[j]) / H[j] - H[j] * (C[j + 1] + 2 * C[j]) / 3;
                D[j] = (C[j + 1] - C[j]) / (3 * H[j]);
            }

            for (i = 0; i <= m; i++)
            {
                if (xval >= x[i] && xval >= x[i + 1])
                {
                    delta = xval - x[i];
                    S = A[i] + B[i] * delta + C[i] * delta * delta + D[i] * delta * delta * delta;
                    break;
                }
            }
            return S;
        }
    }
}
