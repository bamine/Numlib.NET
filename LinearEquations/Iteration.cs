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
                    if(Math.Abs(diagonal)<epsilon)
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
    }
}
