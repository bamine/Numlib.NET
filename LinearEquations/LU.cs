using Numlib.NET;
using Numlib.NET.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquations
{
    public class LU
    {
        const double epsilon = 1.0e-500;

        public static double LUCrout(RMatrix A, RVector b)
        {
            LUDecompose(A);
            return LUSubstitute(A, b);
        }

        public static void LUDecompose(RMatrix matrix)
        {
            int nRows = matrix.GetnRows;
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nRows; j++)
                {
                    double w = matrix[i, j];
                    for (int k = 0; k < Math.Min(i, j); k++)
                    {
                        w -= matrix[i, k] * matrix[k, j];
                    }
                    if (j > i)
                    {
                        double s = matrix[i, i];
                        if (Math.Abs(w) < epsilon)
                        {
                            throw new DivideByZeroException("Diagonal elemnts are too small to normalize");
                        }
                        w /= s;
                    }
                    matrix[i, j] = w;
                }
            }
        }

        public static double LUSubstitute(RMatrix matrix, RVector vector)
        {
            int size = vector.GetVectorSize;
            double det = 1.0;
            for (int i = 0; i < size; i++)
            {
                double w = vector[i];
                for (int j = 0; j < i; j++)
                {
                    w -= matrix[i, j] * vector[j];
                }
                double p = matrix[i, i];
                if (Math.Abs(w) < epsilon)
                {
                    throw new DivideByZeroException("Diagonal elemnts are too small to normalize");
                }
                w /= p;
                vector[i] = w;
                det *= matrix[i, i];
            }
            for (int i = size - 1; i >= 0; i--)
            {
                double s = vector[i];
                for (int j = i + 1; j < size; j++)
                {
                    s -= matrix[i, j] * vector[j];
                }
                vector[i] = s;
            }
            return det;
        }

        public static RMatrix LUInverse(RMatrix matrix)
        {
            var nRows = matrix.GetnRows;
            var u = RMatrix.IndentityMatrix(nRows);
            LUDecompose(matrix);
            var uv = new RVector(nRows);
            for (int i = 0; i < nRows; i++)
            {
                uv = u.GetRowVector(i);
                LUSubstitute(matrix, uv);
                u.ReplaceRow(uv, i);
            }
            var inverse = u.GetTranspose();
            return inverse;
        }
    }
}
