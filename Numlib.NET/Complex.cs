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
        public static Complex COne = new Complex(1.0, 0.0);
        public static Complex i = new Complex(0.0, 1.0);
        public static Complex CNaN = new Complex(double.NaN, double.NaN);
        public static Complex CInfinity = new Complex(double.PositiveInfinity, double.PositiveInfinity);
        public bool IsCZero
        {
            get
            {
                return Real==0.0 || Imag==0;
            }
        }
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

        public static Complex operator +(Complex z)
        {
            return z;
        }

        public static Complex operator -(Complex z)
        {
            return new Complex(-z.Real, -z.Imag);
        }

        public static Complex operator +(Complex z1, Complex z2)
        {
            return new Complex(z1.Real + z2.Real, z1.Imag + z2.Imag);
        }

        public static Complex operator +(double x, Complex z)
        {
            return new Complex(x + z.Real, z.Imag);
        }

        public static Complex operator +(Complex z,double x)
        {
            return new Complex(x + z.Real, z.Imag);
        }

        public static Complex operator -(Complex z1, Complex z2)
        {
            return new Complex(z1.Real - z2.Real, z1.Imag - z2.Imag);
        }
        public static Complex operator -(double x, Complex z)
        {
            return new Complex(x- z.Real,z.Imag);
        }

        public static Complex operator -(Complex z, double x)
        {
            return new Complex(z.Real-x, z.Imag);
        }

        public static Complex operator *(Complex z1, Complex z2)
        {
            double x = z1.Real * z2.Real - z1.Imag * z2.Imag;
            double y = z1.Real * z2.Imag + z1.Imag * z2.Real;
            return new Complex(x, y);
        }

        public static Complex operator *(double x, Complex z)
        {
            return new Complex(x * z.Real, x * z.Imag);
        }

        public static Complex operator *(Complex z, double x)
        {
            return new Complex(x * z.Real, x * z.Imag);
        }

        public static Complex CDiv2(Complex z1, Complex z2)
        {
            double x1 = z1.Real;
            double x2 = z2.Real;
            double y1 = z1.Imag;
            double y2 = z2.Imag;
            Complex u=new Complex(0.0,0.0);
            double denom;
            if (z2.IsCZero) return Complex.CInfinity;

            if (Math.Abs(x2) < Math.Abs(y2))
            {
                denom = x2 * (x2 / y2) + y2;
                u.Real = (x1 * (x2 / y2) + y1) / denom;
                u.Imag = (y1 * (x2 / y2) - x1) / denom;
            }
            else
            {
                denom = y2 * (y2 / x2) + x2;
                u.Real = (y1 * (y2 / x2) + x1) / denom;
                u.Imag = (-x1 * (y2 / x2) + y1) / denom;
            }
            return u;
        }

        public static Complex operator /(Complex z1, Complex z2)
        {
            return CDiv2(z1, z2);
        }

        public static Complex operator /(double x, Complex z)
        {
            return CDiv2(new Complex(x, 0.0), z);
        }

        public static Complex operator /(Complex z, double x)
        {
            if (x == 0.0) return CInfinity;
            return new Complex(z.Real / x, z.Imag / x);
        }

        public static bool operator ==(Complex z1, Complex z2)
        {
            return (z1.Real == z2.Real) && (z1.Imag == z2.Imag);
        }

        public static bool operator !=(Complex z1, Complex z2)
        {
            return !(z1 == z2);
        }

        public override bool Equals(object obj)
        {
            return (obj is Complex) && (this ==(Complex)obj);
        }

        public override int GetHashCode()
        {
            return Real.GetHashCode()^Imag.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0}+{1}i",Real,Imag);
        }

        public static Complex Exp(Complex z)
        {
            double x = z.Real;
            double y = z.Imag;
            double expx = Math.Exp(x);
            return new Complex(expx * Math.Cos(y), expx * Math.Sin(y));
        }

        public static Complex Log(Complex z)
        {
            return new Complex(Math.Log(CNorm2(z)), Math.Atan2(z.Imag, z.Real));
        }

        public static Complex Log2(Complex z)
        {
            double x = z.Real;
            double y = z.Imag;
            double re = 0.5 * Math.Log(x * x + y * y);
            double im = Math.Atan2(y, x);
            return new Complex(re, im);
        }

        public static Complex Log10(Complex z)
        {
            return Complex.Log(z) / Math.Log(10.0);
        }

        public static Complex LogToBase(Complex z1,Complex z2)
        {
            return Complex.Log(z1)/Complex.Log(z2);
        }

        public static Complex Pow(Complex z1, Complex z2)
        {
            return Complex.Exp(z2 * Complex.Log(z1));
        }

        public static Complex Pow2(Complex z1, Complex z2)
        {
            double x1 = z1.Real;
            double x2 = z2.Real;
            double y1 = z1.Imag;
            double y2 = z2.Imag;
            double r1 = Math.Sqrt(x1 * x1 + y1 * y1);
            double theta1 = Math.Atan2(y1, x1);
            double phi = theta1 * x2 + y2 * Math.Log(r1);

            double re = Math.Pow(r1, x2) * Math.Exp(-theta1 * y2) * Math.Cos(phi);
            double im = Math.Pow(r1, x2) * Math.Exp(-theta1 * y2) * Math.Sin(phi);

            return new Complex(re, im);
        }

        public static Complex Pow(Complex z, double x)
        {
            return Complex.Exp(x * Complex.Log2(z));
        }

        public static Complex Pow2(Complex z, double x)
        {
            double x1 = z.Real;
            double y1 = z.Imag;
            double r1 = Math.Sqrt(x1 * x1 + y1 * y1);
            double theta1 = Math.Atan2(y1, x1);
            double phi = theta1 * x;

            double re = Math.Pow(r1, x) * Math.Cos(phi);
            double im = Math.Pow(r1, x) * Math.Sin(phi);

            return new Complex(re, im);
        }

        public static Complex Pow(double x, Complex z)
        {
            return Complex.Exp(z * Math.Log(x));
        }

        public static Complex Pow2(double x, Complex z)
        {
            double x2 = z.Real;
            double y2 = z.Imag;
            double r1 = Math.Sqrt(x*x);
            double theta1 = Math.Atan2(0.0, x);
            double phi = theta1 * x2+y2*Math.Log(r1);

            double re = Math.Pow(r1, x2) * Math.Cos(phi);
            double im = Math.Pow(r1, x2) * Math.Sin(phi);

            return new Complex(re, im);
        }

        public static Complex Root(Complex z, Complex w)
        {
            return Complex.Exp(Complex.Log(z) / w);
        }

        public static Complex Root(Complex z, double x)
        {
            return Complex.Exp(Complex.Log(z) / x);
        }

        public static Complex Root(double x, Complex z)
        {
            return Complex.Exp(Math.Log(x) / z);
        }

        public static Complex Sqrt(Complex z)
        {
            return Complex.Root(z, 2.0);
        }

        public static Complex Sin(Complex z)
        {
            return (Complex.Exp(i * z) - Complex.Exp(-i * z)) / (2.0 * i);
        }

        public static Complex Sin2(Complex z)
        {
            double x = z.Real;
            double y = z.Imag;
            double re = Math.Sin(x) * Math.Cosh(y);
            double im = Math.Cos(x) * Math.Sinh(y);
            return new Complex(re, im);
        }

        public static Complex Cos(Complex z)
        {
            return (Complex.Exp(i * z) + Complex.Exp(-i * z)) / (2.0 * i);
        }

        public static Complex Cos2(Complex z)
        {
            double x = z.Real;
            double y = z.Imag;
            double re = Math.Cos(x) * Math.Cosh(y);
            double im = -Math.Sin(x) * Math.Sinh(y);
            return new Complex(re, im);
        }

        public static Complex Tan(Complex z)
        {
            return Complex.Sin(z) / Complex.Cos(z);
        }

        public static Complex Tan2(Complex z)
        {
            double x2 = 2.0 * z.Real;
            double y2=2.0*z.Imag;
            double denom = Math.Cos(x2) + Math.Cosh(y2);
            if(denom ==0) return CInfinity;
            double re = Math.Sin(x2) / denom;
            double im = Math.Sinh(y2) / denom;

            return new Complex(re, im);
        }
    }
}
