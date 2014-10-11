using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numlib.NET;
using Numlib.NET.Structures;

namespace LinearEquations.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGaussJordan()
        {
            var A = new RMatrix(new double[3,3] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            var b = new RVector(new double[3] { 1, 2, 3 });
            RVector x = GaussJordan.Run(A, b);
            RVector expected=new RVector(new double[3]{1,2,3});
            Assert.IsTrue((x - expected).GetNorm() <= 0.01);
        }

        [TestMethod]
        public void TestLU()
        {
            var A = new RMatrix(new double[3, 3] { { 2, 4, -6 }, { 6, -4, 2 }, { 4, 2, 6 } });
            var b = new RVector(new double[3] { 4, 4, 8 });
            var Anew = A.Clone();
            var Bnew = A.Clone();
            var d = LU.LUCrout(A, b);
            var inverse = LU.LUInverse(Anew);
            var expected = new RMatrix(new double[3, 3] { { 0.0833, 0.1071, 0.04761 }, { 0.0833, -0.1071, 0.119 }, { -0.0833, -0.03571, 0.09523 } });
            var x = inverse * A;
            Assert.IsTrue((inverse*A).GetTrace() -3 <=0.01);
        }

        [TestMethod]
        public void TestGaussJacobi()
        {
            var A = new RMatrix(new double[3, 3] { {4,0,1 }, {0,3,2 }, {1,2,4} });
            var b = new RVector(new double[3] { 2, 1, 3 });
            var A1=A.Clone();
            var b1=b.Clone();
            var x=Iteration.GaussJacobi(A,b,100,1.0e-4);
            Assert.IsTrue((A * x - b).GetNorm() < 0.01);
        }

        [TestMethod]
        public void TestGaussSeidel()
        {
            var A = new RMatrix(new double[3, 3] { { 4, 0, 1 }, { 0, 3, 2 }, { 1, 2, 4 } });
            var b = new RVector(new double[3] { 2, 1, 3 });
            var A1 = A.Clone();
            var b1 = b.Clone();
            var x = Iteration.GaussSeidel(A, b, 100, 1.0e-4);
            Assert.IsTrue((A * x - b).GetNorm() < 0.01);
        }
    }
}
