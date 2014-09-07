using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numlib.NET
{
    public struct RMatrix : ICloneable
    {
        private int nRows;
        private int nCols;
        private double[,] matrix;

        public RMatrix(int nRows, int nCols)
        {
            this.nRows = nRows;
            this.nCols = nCols;
            this.matrix = new double[nRows, nCols];
            for (int i = 0; i < nRows; i++)
            {
                for(int j=0;j<nCols;j++)
                {
                    matrix[i, j] = 0.0;
                }
            }
        }

        public RMatrix(double[,] matrix)
        {
            this.nRows = matrix.GetLength(0);
            this.nCols = matrix.GetLength(1);
            this.matrix = matrix;
        }

        public RMatrix(RMatrix m)
        {
            this.nRows = m.nRows;
            this.nCols = m.nCols;
            this.matrix = m.matrix;
        }

    }
}
