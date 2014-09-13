using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numlib.NET.Structures
{
    public struct CVector : ICloneable
    {
        private int ndim;
        private Complex[] vector;
        #region Constructors
        public CVector(int ndim)
        {
            this.ndim = ndim;
            this.vector = new Complex[ndim];
            for (int i = 0; i < ndim; i++)
            {
                vector[i] = Complex.CZero;
            }
        }

        public CVector(Complex[] vector)
        {
            this.ndim = vector.Length;
            this.vector = vector;
        }
        #endregion

        #region Properties and object methods
        public int GetVectorSize
        {
            get
            {
                return ndim;
            }
        }

        public RVector Real
        {
            get
            {
                return Real(this);
            }
        }

        public RVector Imag
        {
            get
            {
                return Imag(this);
            }
        }

        public CVector Conj()
        {
            return Conj(this);
        }

        public CVector Clone()
        {
            var v = new CVector(vector);
            v.vector = (Complex[])vector.Clone();
            return v;
        }
        object ICloneable.Clone()
        {
            return Clone();
        }

        public void SwapVectorEntries(int m, int n)
        {
            Complex temp = vector[m];
            vector[m] = vector[n];
            vector[n] = temp;
        }

        public override string ToString()
        {
            return "[" + String.Join(",", this.vector) + "]";
        }

        public override bool Equals(object obj)
        {
            return (obj is CVector) && (this.Equals((CVector)obj));
        }

        public bool Equals(CVector v)
        {
            return vector.SequenceEqual(v.vector);
        }

        public override int GetHashCode()
        {
            return vector.GetHashCode();
        }
        #endregion

        #region Operators
        public Complex this[int i]
        {
            get
            {
                if (i < 0 || i > ndim)
                {
                    throw new IndexOutOfRangeException("Requested vector index is out of range !");
                }
                else
                {
                    return vector[i];
                }
            }
            set
            {
                vector[i] = value;
            }
        }

        public static bool operator ==(CVector v1, CVector v2)
        {
            return v1.Equals(v2);
        }

        public static bool operator !=(CVector v1, CVector v2)
        {
            return !v1.Equals(v2);
        }

        public static CVector operator +(CVector v)
        {
            return v;
        }

        public static CVector operator +(CVector v1, CVector v2)
        {
            CVector result = new CVector(v1.ndim);
            for (int i = 0; i < v1.ndim; i++)
            {
                result[i] = v1[i] + v2[i];
            }
            return result;
        }

        public static CVector operator -(CVector v)
        {
            CVector result = new CVector(v.ndim);
            for (int i = 0; i < v.ndim; i++)
            {
                result[i] = -v[i];
            }
            return result;
        }

        public static CVector operator -(CVector v1, CVector v2)
        {
            CVector result = new CVector(v1.ndim);
            for (int i = 0; i < v1.ndim; i++)
            {
                result[i] = v1[i] - v2[i];
            }
            return result;
        }

        public static CVector operator *(double d, CVector v)
        {
            CVector result = new CVector(v.ndim);
            for (int i = 0; i < v.ndim; i++)
            {
                result[i] = d * v[i];
            }
            return result;
        }

        public static CVector operator *(CVector v, double d)
        {
            return d * v;
        }

        public static CVector operator /(CVector v, double d)
        {
            CVector result = new CVector(v.ndim);
            for (int i = 0; i < v.ndim; i++)
            {
                result[i] = v[i] / d;
            }
            return result;
        }

        public static RVector Real(CVector v)
        {
            return new RVector(v.vector.Select(c => c.Real).ToArray());
        }

        public static RVector Imag(CVector v)
        {
            return new RVector(v.vector.Select(c => c.Real).ToArray());
        }

        public static CVector Conj(CVector v)
        {
            return new CVector(v.vector.Select(c => Complex.Conj(c)).ToArray());
        }

        public static double DotProduct(CVector v1, CVector v2)
        {
            double result = 0.0;
            for (int i = 0; i < v1.ndim; i++)
            {
                result += Complex.Conj(v1[i]) * v2[i];
            }
            return result;
        }

        public double GetNorm()
        {
            return Math.Sqrt(DotProduct(this, this));
        }

        public double GetNormSquare()
        {
            return DotProduct(this, this);
        }

        public void Normalize()
        {
            var norm = GetNorm();
            if (norm == 0)
            {
                throw new InvalidOperationException("Tried to normalize a vector with norm of zero!");
            }
            for (int i = 0; i < ndim; i++)
            {
                vector[i] /= norm;
            }
        }

        public CVector GetUnitVector()
        {
            CVector result = new CVector(vector);
            result.Normalize();
            return result;
        }

        public static CVector CrossProduct(CVector v1, CVector v2)
        {
            if (v1.ndim != 3)
            {
                throw new ArgumentException("The First vector must be of dimension 3 !");
            }
            if (v2.ndim != 3)
            {
                throw new ArgumentException("The Second vector must be of dimension 3 !");
            }
            CVector result = new CVector(3);
            result[0] = v1[1] * v2[2] - v1[2] * v2[1];
            result[1] = v1[2] * v2[0] - v1[0] * v2[2];
            result[2] = v1[0] * v2[1] - v1[1] * v2[0];
            return result;
        }
        #endregion
    }
}

