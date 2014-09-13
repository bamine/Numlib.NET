using Numlib.NET.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numlib.NET
{
    public struct CMatrix : ICloneable
    {
        private int nRows;
        private int nCols;
        private Complex[][] matrix;

        public CMatrix(int nRows, int nCols)
        {
            this.nRows = nRows;
            this.nCols = nCols;
            this.matrix = new Complex[nRows][];
            for (int i = 0; i < nRows; i++)
            {
                matrix[i] = new Complex[nCols];
                for (int j = 0; j < nCols; j++)
                {
                    matrix[i][j] = Complex.CZero;
                }
            }
        }

        public CMatrix(Complex[][] matrix)
        {
            this.nRows = matrix.GetLength(0);
            this.nCols = matrix.GetLength(1);
            this.matrix = matrix;
        }

        public CMatrix(CMatrix m)
        {
            this.nRows = m.nRows;
            this.nCols = m.nCols;
            this.matrix = m.matrix;
        }

        public CMatrix Clone()
        {
            var m = new CMatrix(matrix);
            m.matrix = (Complex[][])matrix.Clone();
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

        public static CMatrix IndentityMatrix(int n)
        {
            var I = new CMatrix(n, n);
            for (int i = 0; i < n; i++)
            {
                I[i, i] = Complex.COne;
            }
            return I;
        }

        public Complex this[int m, int n]
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
            return (obj is CMatrix) && (this.Equals((CMatrix)obj));
        }

        public bool Equals(CMatrix m)
        {
            return matrix == m.matrix;
        }

        public override int GetHashCode()
        {
            return matrix.GetHashCode();
        }

        public static bool operator ==(CMatrix m1, CMatrix m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(CMatrix m1, CMatrix m2)
        {
            return !m1.Equals(m2);
        }

        public static bool DimensionsEquals(CMatrix m1, CMatrix m2)
        {
            return (m1.nRows == m2.nRows) && (m1.nCols == m2.nCols);
        }

        public static bool DimensionsEquals(CMatrix m1, RMatrix m2)
        {
            return (m1.nRows == m2.GetnRows) && (m1.nCols == m2.GetnCols);
        }

        public static bool DimensionsEquals(RMatrix m1, CMatrix m2)
        {
            return (m1.GetnRows == m2.nRows) && (m1.GetnCols == m2.nCols);
        }

        public static CMatrix operator +(CMatrix m)
        {
            return m;
        }

        public static CMatrix operator -(CMatrix m)
        {
            for (int i = 0; i < m.nRows; i++)
            {
                for (int j = 0; j < m.nCols; j++)
                {
                    m[i, j] = -m[i, j];
                }
            }
            return m;
        }

        public static CMatrix operator +(CMatrix m1, CMatrix m2)
        {
            if (!CMatrix.DimensionsEquals(m1, m2))
            {
                throw new ArgumentException("Matrix dimensions must match !");
            }
            var result = new CMatrix(m1.GetnRows, m1.GetnRows);
            for (int i = 0; i < m1.nRows; i++)
            {
                for (int j = 0; j < m1.nCols; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return result;
        }

        public static CMatrix operator +(CMatrix m1, RMatrix m2)
        {
            if (!CMatrix.DimensionsEquals(m1, m2))
            {
                throw new ArgumentException("Matrix dimensions must match !");
            }
            var result = new CMatrix(m1.GetnRows, m1.GetnRows);
            for (int i = 0; i < m1.nRows; i++)
            {
                for (int j = 0; j < m1.nCols; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return result;
        }

        public static CMatrix operator +(RMatrix m1, CMatrix m2)
        {
            return m2 + m1;
        }

        public static CMatrix operator -(CMatrix m1, CMatrix m2)
        {
            if (!CMatrix.DimensionsEquals(m1, m2))
            {
                throw new ArgumentException("Matrix dimensions must match !");
            }
            var result = new CMatrix(m1.GetnRows, m1.GetnRows);
            for (int i = 0; i < m1.nRows; i++)
            {
                for (int j = 0; j < m1.nCols; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return result;
        }

        public static CMatrix operator -(RMatrix m1, CMatrix m2)
        {
            if (!CMatrix.DimensionsEquals(m1, m2))
            {
                throw new ArgumentException("Matrix dimensions must match !");
            }
            var result = new CMatrix(m1.GetnRows, m1.GetnRows);
            for (int i = 0; i < m1.GetnRows; i++)
            {
                for (int j = 0; j < m1.GetnCols; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return result;
        }

        public static CMatrix operator -(CMatrix m1, RMatrix m2)
        {
            if (!CMatrix.DimensionsEquals(m1, m2))
            {
                throw new ArgumentException("Matrix dimensions must match !");
            }
            var result = new CMatrix(m1.GetnRows, m1.GetnRows);
            for (int i = 0; i < m1.GetnRows; i++)
            {
                for (int j = 0; j < m1.GetnCols; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return result;
        }

        public static CMatrix operator *(CMatrix m, double d)
        {
            var result = new CMatrix(m.GetnRows, m.GetnRows);
            for (int i = 0; i < m.nRows; i++)
            {
                for (int j = 0; j < m.nCols; j++)
                {
                    result[i, j] = d * m[i, j];
                }
            }
            return result;
        }

        public static CMatrix operator *(double d, CMatrix m)
        {
            return m * d;
        }

        public static CMatrix operator /(CMatrix m, double d)
        {
            var result = new CMatrix(m.GetnRows, m.GetnRows);
            for (int i = 0; i < m.nRows; i++)
            {
                for (int j = 0; j < m.nCols; j++)
                {
                    result[i, j] = m[i, j] / d;
                }
            }
            return result;
        }

        public static CMatrix operator *(CMatrix m1, CMatrix m2)
        {
            if (m1.GetnCols != m2.GetnRows)
            {
                throw new ArgumentException("The number of columns of the first matrix must be equal to the number of columns of the second matrix !");
            }
            Complex tmp = Complex.CZero;
            var result = new CMatrix(m1.GetnRows, m2.GetnCols);
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

        public static CMatrix operator *(RMatrix m1, CMatrix m2)
        {
            if (m1.GetnCols != m2.GetnRows)
            {
                throw new ArgumentException("The number of columns of the first matrix must be equal to the number of columns of the second matrix !");
            }
            Complex tmp = Complex.CZero;
            var result = new CMatrix(m1.GetnRows, m2.GetnCols);
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

        public static CMatrix operator *(CMatrix m1, RMatrix m2)
        {
            if (m1.GetnCols != m2.GetnRows)
            {
                throw new ArgumentException("The number of columns of the first matrix must be equal to the number of columns of the second matrix !");
            }
            Complex tmp = Complex.CZero;
            var result = new CMatrix(m1.GetnRows, m2.GetnCols);
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

        public static RVector operator *(CMatrix m, RVector v)
        {
            if (m.GetnCols != v.GetVectorSize)
            {
                throw new ArgumentException("matrix columns number must matche vector size !");
            }
            RVector result = new RVector(m.GetnCols);
            for (int i = 0; i < m.nRows; i++)
            {
                result[i] = 0.0;
                for (int j = 0; j < m.nCols; j++)
                {
                    result[i] += m[i, j] * v[j];
                }
            }
            return result;
        }

        public static RVector operator *(CMatrix m, CVector v)
        {
            if (m.GetnCols != v.GetVectorSize)
            {
                throw new ArgumentException("matrix columns number must matche vector size !");
            }
            RVector result = new RVector(m.GetnCols);
            for (int i = 0; i < m.nRows; i++)
            {
                result[i] = 0.0;
                for (int j = 0; j < m.nCols; j++)
                {
                    result[i] += m[i, j] * v[j];
                }
            }
            return result;
        }

        public static RVector operator *(RVector v, CMatrix m)
        {
            if (m.GetnRows != v.GetVectorSize)
            {
                throw new ArgumentException("matrix rows number must matche vector size !");
            }
            RVector result = new RVector(m.GetnRows);
            for (int i = 0; i < m.nCols; i++)
            {
                result[i] = 0.0;
                for (int j = 0; j < m.nRows; j++)
                {
                    result[i] += m[j, i] * v[j];
                }
            }
            return result;
        }

        public static RVector operator *(CVector v, CMatrix m)
        {
            if (m.GetnRows != v.GetVectorSize)
            {
                throw new ArgumentException("matrix rows number must matche vector size !");
            }
            RVector result = new RVector(m.GetnRows);
            for (int i = 0; i < m.nCols; i++)
            {
                result[i] = 0.0;
                for (int j = 0; j < m.nRows; j++)
                {
                    result[i] += m[j, i] * v[j];
                }
            }
            return result;
        }

        public static CMatrix Transform(CVector v1, CVector v2)
        {
            var result = new CMatrix(v1.GetVectorSize, v2.GetVectorSize);
            for (int i = 0; i < result.GetnRows; i++)
            {
                for (int j = 0; j < result.GetnCols; j++)
                {
                    result[i, j] = v1[i] * v2[j];
                }
            }
            return result;
        }
        public void Transpose()
        {
            CMatrix m = new CMatrix(nRows, nCols);
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                {
                    m[j, i] = matrix[i][j];
                }
            }
            this = m;
        }

        public CMatrix GetTranspose()
        {
            CMatrix m = this;
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

        public CVector GetRowVector(int m)
        {
            if (m < 0 || m > nRows)
            {
                throw new IndexOutOfRangeException("row is out of range !");
            }
            return new CVector(matrix[m]);
        }

        public CVector GetColVector(int n)
        {
            if (n < 0 || n > nRows)
            {
                throw new IndexOutOfRangeException("col is out of range !");
            }
            var result = new CVector(nRows);
            for (int i = 0; i < nRows; i++)
            {
                result[i] = matrix[i][n];
            }
            return result;
        }

        public void ReplaceRow(CVector v, int m)
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

        public void ReplaceCol(CVector v, int n)
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
            var temp = Complex.CZero;
            for (int i = 0; i < nCols; i++)
            {
                temp = matrix[n][i];
                matrix[n][i] = matrix[m][i];
                matrix[m][i] = temp;
            }
        }

        public void SwapMatrixCols(int m, int n)
        {
            var temp = Complex.CZero;
            for (int i = 0; i < nCols; i++)
            {
                temp = matrix[i][n];
                matrix[i][n] = matrix[i][m];
                matrix[i][m] = temp;
            }
        }

        public static Complex Determinant(CMatrix m)
        {
            var result = Complex.CZero;
            if (!m.IsSquare())
            {
                throw new ArgumentException("Matrix must be square !");
            }
            if (m.GetnRows == 1)
            {
                result = m[0, 0];
            }
            else
            {
                for (int i = 0; i < m.GetnRows; i++)
                {
                    result += Math.Pow(-1, i) * m[0, i] * Determinant(CMatrix.Minor(m, 0, i));
                }
            }
            return result;
        }

        public static CMatrix Minor(CMatrix m, int row, int col)
        {
            var mm = new CMatrix(m.GetnRows - 1, m.GetnCols - 1);
            int ii = 0;
            int jj = 0;
            for (int i = 0; i < m.GetnRows; i++)
            {
                if (i == row) continue;
                jj = 0;
                for (int j = 0; j < m.GetnCols; j++)
                {
                    if (j == col) continue;
                    mm[ii, jj] = m[i, j];
                    jj++;
                }
                ii++;
            }
            return mm;
        }

        public static CMatrix Adjoint(CMatrix m)
        {
            if (!m.IsSquare())
            {
                throw new ArgumentException("Matrix must be square !");
            }
            var adj = new CMatrix(m.GetnRows, m.GetnCols);
            for (int i = 0; i < m.GetnRows; i++)
            {
                for (int j = 0; j < m.GetnRows; j++)
                {
                    adj[i, j] = Math.Pow(-1, i + j) * Determinant(Minor(m, i, j));
                }
            }
            return m.GetTranspose();
        }

        public static CMatrix Inverse(CMatrix m)
        {
            var det = Determinant(m);
            if (det == 0.0)
            {
                throw new ArgumentException("Cannot invert a non-invertible matrix !");
            }
            return Adjoint(m) / det;
        }
    }
}
