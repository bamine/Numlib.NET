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
        private double[][] matrix;

        public RMatrix(int nRows, int nCols)
        {
            this.nRows = nRows;
            this.nCols = nCols;
            this.matrix = new double[nRows][];
            for (int i = 0; i < nRows; i++)
            {
                matrix[i] = new double[nCols];
                for(int j=0;j<nCols;j++)
                {
                    matrix[i][j] = 0.0;
                }
            }
        }

        public RMatrix(double[][] matrix)
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

        public RMatrix Clone()
        {
            var m = new RMatrix(matrix);
            m.matrix = (double[][])matrix.Clone();
            return m;
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public int GetnRows
        {
            get
            {
                return nRows;
            }
        }

        public int GetnCols
        {
            get
            {
                return nCols;
            }
        }

        public static RMatrix IndentityMatrix(int n)
        {
            var I = new RMatrix(n, n);
            for (int i = 0; i < n; i++)
            {
                I[i, i] = 1.0;
            }
            return I;
        }

        public double this[int m, int n]
        {
            get
            {
                if (m < 0 || m > nRows)
                {
                    throw new IndexOutOfRangeException("m-th row is out of range !");
                }
                if (n < 0 || n > nCols)
                {
                    throw new IndexOutOfRangeException("n-th col is out of range !");
                }
                return matrix[m][n];
            }
            set
            {
                if (m < 0 || m > nRows)
                {
                    throw new IndexOutOfRangeException("m-th row is out of range !");
                }
                if (n < 0 || n > nCols)
                {
                    throw new IndexOutOfRangeException("n-th col is out of range !");
                }
                matrix[m][n] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < nRows; i++)
            {
                str.Append("[");
                str.Append(String.Join(" ", matrix[i]));
                str.Append("]\n");
            }
            return str.ToString();
        }


       
    }
}
