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
        public static Complex Conj(Complex z)
        {
            return new Complex(z.Real, -z.Imag);
        }
        public static double CNorm(Complex z)
        {
            return Math.Sqrt(z.Real * z.Real + z.Imag * z.Imag);
        }
        /// <summary>
        /// Returns the norm (or modulus) of a complex avoiding potential underflow or overflow problems
        /// </summary>
        /// <param name="z"></param>
        /// <returns>Norm of z</returns>
        public static double CNorm2(Complex z)
        {
            double x = z.Real;
            double y = z.Imag;
            if (Math.Abs(x) < Math.Abs(y))
            {
                return (Math.Abs(y) * Math.Sqrt(1.0 + (x / y) * (x / y)));
            }
            else
            {
                return (Math.Abs(x) * Math.Sqrt(1.0 + (y / x) * (y / x)));
            }
        }

        public static Complex Inv(Complex z)
        {
            return 1.0 / z;
        }
        public static double Re(Complex z)
        {
            return z.Real;
        }
        public static double Im(Complex z)
        {
            return z.Imag;
        }
        public static Complex FromPolar(double r, double theta)
        {
            return new Complex(r * Math.Cos(theta), r * Math.Sin(theta));
        }


    }
}
