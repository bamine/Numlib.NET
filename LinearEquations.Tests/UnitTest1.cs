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
    }
}
