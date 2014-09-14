using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numlib.NET.Structures
{
    public struct RVector : ICloneable
    {
        private int ndim;
        private double[] vector;
        #region Constructors
        public RVector(int ndim)
        {
            this.ndim = ndim;
            this.vector = new double[ndim];
            for (int i = 0; i < ndim; i++)
            {
                vector[i] = 0.0;
            }
        }

        public RVector(double[] vector)
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


        public RVector Clone()
        {
            var v = new RVector(vector);
            v.vector = (double[])vector.Clone();
            return v;
        }
        object ICloneable.Clone()
        {
            return Clone();
        }

        public void SwapVectorEntries(int m, int n)
        {
            double temp = vector[m];
            vector[m] = vector[n];
            vector[n] = temp;
        }

        public override string ToString()
        {
            return "[" + String.Join(",", this.vector) + "]";
        }

        public override bool Equals(object obj)
        {
            return (obj is RVector) && (this.Equals((RVector)obj));
        }

        public bool Equals(RVector v)
        {
            return vector.SequenceEqual(v.vector);
        }

        public override int GetHashCode()
        {
            return vector.GetHashCode();
        }
        #endregion

        #region Operators
        public double this[int i]
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

        public static bool operator ==(RVector v1, RVector v2)
        {
            return v1.Equals(v2);
        }

        public static bool operator !=(RVector v1, RVector v2)
        {
            return !v1.Equals(v2);
        }

        public static RVector operator +(RVector v)
        {
            return v;
        }

        public static RVector operator +(RVector v1, RVector v2)
        {
            RVector result = new RVector(v1.ndim);
            for (int i = 0; i < v1.ndim; i++)
            {
                result[i] = v1[i] + v2[i];
            }
            return result;
        }

        public static RVector operator -(RVector v)
        {
            RVector result = new RVector(v.ndim);
            for (int i = 0; i < v.ndim; i++)
            {
                result[i] = -v[i];
            }
            return result;
        }

        public static RVector operator -(RVector v1, RVector v2)
        {
            RVector result = new RVector(v1.ndim);
            for (int i = 0; i < v1.ndim; i++)
            {
                result[i] = v1[i] - v2[i];
            }
            return result;
        }

        public static RVector operator *(double d, RVector v)
        {
            RVector result = new RVector(v.ndim);
            for (int i = 0; i < v.ndim; i++)
            {
                result[i] = d * v[i];
            }
            return result;
        }

        public static RVector operator *(RVector v, double d)
        {
            return d * v;
        }

        public static RVector operator /(RVector v, double d)
        {
            RVector result = new RVector(v.ndim);
            for (int i = 0; i < v.ndim; i++)
            {
                result[i] = v[i] / d;
            }
            return result;
        }

        public static double DotProduct(RVector v1, RVector v2)
        {
            double result = 0.0;
            for (int i = 0; i < v1.ndim; i++)
            {
                result += (v1[i] * v2[i]);
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

        public RVector GetUnitVector()
        {
            RVector result = new RVector(vector);
            result.Normalize();
            return result;
        }

        public static RVector CrossProduct(RVector v1, RVector v2)
        {
            if (v1.ndim != 3)
            {
                throw new ArgumentException("The First vector must be of dimension 3 !");
            }
            if (v2.ndim != 3)
            {
                throw new ArgumentException("The Second vector must be of dimension 3 !");
            }
            RVector result = new RVector(3);
            result[0] = v1[1] * v2[2] - v1[2] * v2[1];
            result[1] = v1[2] * v2[0] - v1[0] * v2[2];
            result[2] = v1[0] * v2[1] - v1[1] * v2[0];
            return result;
        }
        #endregion
    }
}
