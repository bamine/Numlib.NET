using Numlib.NET;
using Numlib.NET.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquations
{
    public class GaussJordan
    {
        const double epsilon = 1.0e-50;

        public static RVector Run(RMatrix A, RVector b)
        {
            Triangulate(ref A, ref b);
            int bSize = b.GetVectorSize;
            RVector x = new RVector(bSize);
            for (int i = bSize - 1; i >= 0; i--)
            {
                double Aii = A[i, i];
                if (Math.Abs(Aii) < epsilon)
                {
                    throw new DivideByZeroException("Diagonal elemnts are too small to normalize");
                }
                x[i] = (b[i] - RVector.DotProduct(A.GetRowVector(i), x)) / Aii;
            }
            return x;
        }

        private static void Triangulate(ref RMatrix A, ref RVector b)
        {
            int nRows = A.GetnRows;
            for (int i = 0; i < nRows - 1; i++)
            {
                double diagonalElement = PivotGaussJordan(A, b, i);
                if (Math.Abs(diagonalElement) < epsilon)
                {
                    throw new DivideByZeroException("Diagonal elemnts are too small to normalize");
                }
                for (int j = i + 1; j < nRows; j++)
                {
                    double w = A[i, j] / diagonalElement;
                    for (int k = i + 1; k < nRows; k++)
                    {
                        A[j, k] -= w * A[i, k];
                    }
                    b[j] -= w * b[i];
                }
            }
        }

        private static double PivotGaussJordan(RMatrix A, RVector b, int q)
        {
            int bSize = b.GetVectorSize;
            int c = q;
            double d = 0.0;
            for (int j = q; j < bSize; j++)
            {
                double w = Math.Abs(A[j, q]);
                if (w > d)
                {
                    d = w;
                    c = j;
                }
            }
            if (c > q)
            {
                A.SwapMatrixRows(q, c);
                b.SwapVectorEntries(q, c);
            }
            return A[q, q];
        }
    }
}
