using Numlib.NET;
using Numlib.NET.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquations
{
    public class Iteration
    {
        const double epsilon = 1.0e-500;

        public static RVector GaussJacobi(RMatrix A, RVector b, int maxIterations, double tolerance)
        {
            int bSize = b.GetVectorSize;
            var x = new RVector(bSize);
            for (int iter = 0; iter < maxIterations; iter++)
            {
                var xOld = x.Clone();
                for (int i = 0; i < bSize; i++)
                {
                    var entry = b[i];
                    var diagonal = A[i, i];
                    if (Math.Abs(diagonal) < epsilon)
                    {
                        throw new DivideByZeroException("Diagonal elemnts are too small to normalize");
                    }
                    for (int j = 0; j < bSize; j++)
                    {
                        if (j != i)
                        {
                            entry -= A[i, j] * xOld[j];
                        }
                    }
                    x[i] = entry / diagonal;
                }
                var dx = x - xOld;
                if (dx.GetNorm() < tolerance)
                {
                    return x;
                }
            }
            return x;
        }

        public static RVector GaussSeidel(RMatrix A, RVector b, int maxIterations, double tolerance)
        {
            var size = b.GetVectorSize;
            var x = new RVector(size);
            for (int iter = 0; iter < maxIterations; iter++)
            {
                RVector xOld = x.Clone();
                for (int i = 0; i < size; i++)
                {
                    var entry = b[i];
                    var diagonal = A[i, i];
                    if (Math.Abs(diagonal) < epsilon)
                    {
                        throw new DivideByZeroException("Diagonal elemnts are too small to normalize");
                    }
                    for (int j = 0; j < i; j++)
                    {
                        entry -= A[i, j] * x[j];
                    }
                    for (int j = i + 1; j < size; j++)
                    {
                        entry -= A[i, j] * xOld[j];
                    }
                    x[i] = entry / diagonal;
                }
                var dx = x - xOld;
                if (dx.GetNorm() < tolerance)
                {
                    return x;
                }
            }
            return x;
        }

        public static void JacobiEigen(RMatrix A, int maxsize, int n, double epsilon, out RMatrix eigenval, out RMatrix eigenvec)
        {
            int i, j, p, q, flag;
            var d = new RMatrix(n, n);
            var s = new RMatrix(n, n);
            var s1 = new RMatrix(n, n);
            var s1t = new RMatrix(n, n);
            var temp = new RMatrix(n, n);
            double theta, max;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    d[i, j] = A[i, j];
                    if (i == j)
                    {
                        s[i, j] = 1.0;
                    }
                    else
                    {
                        s[i, j] = 0.0;
                    }
                }
            }

            flag = 1;
            while (flag == 1)
            {
                flag = 0;
                i = 0;
                j = 1;
                max = Math.Abs(d[0, 1]);
                for (p = 0; p < n; p++)
                {
                    for (q = 0; q < n; q++)
                    {
                        if (p != q)
                        {
                            if (max < Math.Abs(d[p, q]))
                            {
                                max = Math.Abs(d[p, q]);
                                i = p;
                                j = q;
                            }
                        }
                    }
                }

                if (d[i, i] == d[j, j])
                {
                    if (d[i, j] > 0)
                    {
                        theta = Math.PI / 4.0;
                    }
                    else
                    {
                        theta = -Math.PI / 4.0;
                    }
                }
                else
                {
                    theta = 0.5 * Math.Atan(2.0 * d[i, j] / (d[i, i] - d[j, j]));
                    if (Double.IsNaN(theta))
                    {
                        break;
                    }
                }

                for (p = 0; p < n; p++)
                {
                    s1[p, p] = 1.0;
                    s1t[p, p] = 1.0;
                }

                s1[i, i] = Math.Cos(theta);
                s1[j, j] = s1[i, i];
                s1[j, i] = Math.Sin(theta);
                s1[i, j] = -s1[j, i];

                s1t[i, i] = s1[i, i];
                s1t[j, j] = s1[j, j];
                s1t[i, j] = s1[j, i];
                s1t[j, i] = s1[i, j];

                d = s1t * d * s1;
                s = s * s1;

                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        if (j != i)
                        {
                            if (Math.Abs(d[i, j]) > epsilon)
                            {
                                flag = 1;
                            }
                        }
                    }
                }
            };
            eigenval = d;
            eigenvec = s;
        }

        public static void JacobiEigenValVec(RMatrix a, int maxsize, int n, double epsilon, out RMatrix eigenval, out RMatrix eigenvec)
        {
            int i, j, p, q, flag;
            double[,] d = new double[maxsize, maxsize];
            double[,] s = new double[maxsize, maxsize];
            double[,] s1 = new double[maxsize, maxsize];
            double[,] s1t = new double[maxsize, maxsize];
            double[,] temp = new double[maxsize, maxsize];
            double theta, max;
            //Initialization of matrix d and s
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    d[i, j] = a[i, j];
                    s[i, j] = 0.0;
                }
            }
            for (i = 0; i < n; i++) s[i, i] = 1.0;
            do
            {
                flag = 0;
                //Find largest off-diagonal element
                i = 0;
                j = 1;
                max = Math.Abs(d[0, 1]);
                for (p = 0; p < n; p++)
                {
                    for (q = 0; q < n; q++)
                    {
                        if (p != q) //off diagonal element
                        {
                            if (max < Math.Abs(d[p, q]))
                            {
                                max = Math.Abs(d[p, q]);
                                i = p;
                                j = q;
                            }
                        }
                    }
                }
                if (d[i, i] == d[j, j])
                {
                    if (d[i, j] > 0) theta = Math.PI / 4.0;
                    else theta = -Math.PI / 4.0;
                }
                else
                {
                    theta = 0.5 * Math.Atan(2.0 * d[i, j] / (d[i, i] - d[j, j]));
                }
                //Construction of the matrix s1 and s1t
                for (p = 0; p < n; p++)
                {
                    for (q = 0; q < n; q++)
                    {
                        s1[p, q] = 0.0;
                        s1t[p, q] = 0.0;
                    }
                }
                for (p = 0; p < n; p++)
                {
                    s1[p, p] = 1.0;
                    s1t[p, p] = 1.0;
                }
                s1[i, i] = Math.Cos(theta); s1[j, j] = s1[i, i];
                s1[j, i] = Math.Sin(theta); s1[i, j] = -s1[j, i];
                s1t[i, i] = s1[i, i]; s1t[j, j] = s1[j, j];
                s1t[i, j] = s1[j, i]; s1t[j, i] = s1[i, j];
                //Product of s1t and d
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        temp[i, j] = 0.0;
                        for (p = 0; p < n; p++)
                            temp[i, j] += s1t[i, p] * d[p, j];
                    }
                }
                //Product of temp and s1: d = s1t * d * s1
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        d[i, j] = 0.0;
                        for (p = 0; p < n; p++)
                            d[i, j] += temp[i, p] * s1[p, j];
                    }
                }
                //Product of s and s1: s = s*s1
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        temp[i, j] = 0.0;
                        for (p = 0; p < n; p++)
                            temp[i, j] += s[i, p] * s1[p, j];
                    }
                }
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        s[i, j] = temp[i, j];
                    }
                }
                //check to see if d is a diagonal matrix
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        if (i != j)
                            if (Math.Abs(d[i, j]) > epsilon)
                                flag = 1;
                    }
                }
            } while (flag == 1);
            //copy results to output matrices
            eigenval = new RMatrix(d);
            eigenvec = new RMatrix(s);
        }
    }
}
