using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numlib.NET
{
    public struct Complex
    {
        public double Real { set; get; }
        public double Imag { set; get; }

        public Complex(double r, double i)
            : this()
        {
            this.Real = r;
            this.Imag = i;
        }

        public static implicit operator double(Complex z)
        {
            return z.Real;
        }
        public static explicit operator Complex(double x)
        {
            return new Complex(x, 0.0);
        }
        public static Complex CZero = new Complex(0.0, 0.0);
        public static Complex COnr = new Complex(1.0, 0.0);
        public static Complex i = new Complex(0.0, 1.0);
        public static Complex CNaN = new Complex(double.NaN, double.NaN);
        public static Complex CInfinity = new Complex(double.PositiveInfinity, double.PositiveInfinity);
        public bool IsCNan
        {
            get
            {
                return double.IsNaN(Real) || double.IsNaN(Imag);
            }
        }
        public bool IsCInfinity
        {
            get
            {
                return double.IsInfinity(Real) || double.IsInfinity(Imag);
            }
        }
        public static double Arg(Complex z)
        {
            return Math.Atan2(z.Imag, z.Real);
        }

    }
}
