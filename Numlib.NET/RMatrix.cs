using Numlib.NET.Structures;
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

        public override bool Equals(object obj)
        {
            return (obj is RMatrix) && (this.Equals((RMatrix) obj));
        }

        public bool Equals(RMatrix m)
        {
            return matrix == m.matrix;
        }

        public override int GetHashCode()
        {
            return matrix.GetHashCode();
        }

        public static bool operator ==(RMatrix m1, RMatrix m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(RMatrix m1, RMatrix m2)
        {
            return !m1.Equals(m2);
        }

        public static bool DimensionsEquals(RMatrix m1,RMatrix m2)
        {
            return (m1.nRows == m2.nRows) && (m1.nCols == m2.nCols);
        }

        public static RMatrix operator +(RMatrix m){
            return m;
        }

        public static RMatrix operator -(RMatrix m)
        {
            for(int i=0;i<m.nRows;i++){
                for(int j=0;j<m.nCols;j++){
                    m[i, j] = -m[i, j];
                }
            }
            return m;
        }

        public static RMatrix operator +(RMatrix m1, RMatrix m2)
        {
            if (!RMatrix.DimensionsEquals(m1, m2))
            {
                throw new ArgumentException("Matrix dimensions must match !");
            }
            var result = new RMatrix(m1.GetnRows, m1.GetnRows);
            for (int i = 0; i < m1.nRows; i++)
            {
                for (int j = 0; j < m1.nCols; j++)
                {
                    result[i, j] = m1[i, j]+m2[i,j];
                }
            }
            return result;
        }

        public static RMatrix operator -(RMatrix m1, RMatrix m2)
        {
            if (!RMatrix.DimensionsEquals(m1, m2))
            {
                throw new ArgumentException("Matrix dimensions must match !");
            }
            var result = new RMatrix(m1.GetnRows, m1.GetnRows);
            for (int i = 0; i < m1.nRows; i++)
            {
                for (int j = 0; j < m1.nCols; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return result;
        }

        public static RMatrix operator *(RMatrix m, double d)
        {
            var result = new RMatrix(m.GetnRows, m.GetnRows);
            for (int i = 0; i < m.nRows; i++)
            {
                for (int j = 0; j < m.nCols; j++)
                {
                    result[i, j] = d* m[i, j];
                }
            }
            return result;
        }

        public static RMatrix operator *(double d, RMatrix m)
        {
            return m * d;
        }

        public static RMatrix operator /(RMatrix m, double d)
        {
            var result = new RMatrix(m.GetnRows, m.GetnRows);
            for (int i = 0; i < m.nRows; i++)
            {
                for (int j = 0; j < m.nCols; j++)
                {
                    result[i, j] = m[i, j]/d;
                }
            }
            return result;
        }

        public static RMatrix operator *(RMatrix m1, RMatrix m2)
        {
            if (m1.GetnCols != m2.GetnRows)
            {
                throw new ArgumentException("The number of columns of the first matrix must be equal to the number of columns of the second matrix !");
            }
            double tmp = 0.0;
            var result = new RMatrix(m1.GetnRows, m2.GetnCols);
            for (int i = 0; i < m1.GetnRows; i++)
            {
                for (int j = 0; i < m2.GetnCols; j++)
                {
                    tmp = result[i, j];
                    for (int k = 0; k < result.GetnRows; k++)
                    {
                        tmp += m1[i, k] * m2[k, j];
                    }
                    result[i, j] = tmp;
                }
            }
            return result;
        }

        public void Transpose()
        {
            RMatrix m = new RMatrix(nRows, nCols);
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                {
                    m[j, i] = matrix[i][j];
                }
            }
            this = m;
        }

        public RMatrix GetTranspose()
        {
            RMatrix m = this;
            m.Transpose();
            return m;
        }

        public double GetTrace()
        {
            double trace = 0.0;
            for (int i = 0; i < nRows; i++)
            {
                if (i < nCols)
                {
                    trace += matrix[i][i];
                }
            }
            return trace;
        }

        public bool IsSquare()
        {
            return nRows == nCols;
        }

        public RVector GetRowVector(int m)
        {
            if (m < 0 || m > nRows)
            {
                throw new IndexOutOfRangeException("row is out of range !");
            }
            return new RVector(matrix[m]);
        }

        public RVector GetColVector(int n)
        {
            if (n < 0 || n > nRows)
            {
                throw new IndexOutOfRangeException("col is out of range !");
            }
            var result = new RVector(nRows);
            for (int i = 0; i < nRows; i++)
            {
                result[i] = matrix[i][n];
            }
            return result;
        }

        public void ReplaceRow(RVector v, int m)
        {
            if (m < 0 || m > nRows)
            {
                throw new IndexOutOfRangeException("row is out of range !");
            }
            if (v.GetVectorSize != nCols)
            {
                throw new ArgumentException("Vector size must match matrix number of column !");
            }
            for (int i = 0; i < nCols; i++)
            {
                matrix[m][i] = v[i];
            }
        }

        public void ReplaceCol(RVector v, int n)
        {
            if (n < 0 || n > nRows)
            {
                throw new IndexOutOfRangeException("col is out of range !");
            }
            if (v.GetVectorSize != nCols)
            {
                throw new ArgumentException("Vector size must match matrix number of rows !");
            }
            for (int i = 0; i < nCols; i++)
            {
                matrix[i][n] = v[i];
            }
        }

        public void SwapMatrixRows(int m, int n)
        {
            double temp = 0.0;
            for (int i = 0; i < nCols; i++)
            {
                temp = matrix[n][i];
                matrix[n][i] = matrix[m][i];
                matrix[m][i] = temp;
            }
        }

        public void SwapMatrixCols(int m, int n)
        {
            double temp = 0.0;
            for (int i = 0; i < nCols; i++)
            {
                temp = matrix[i][n];
                matrix[i][n] = matrix[i][m];
                matrix[i][m] = temp;
            }
        }
       
    }
}
