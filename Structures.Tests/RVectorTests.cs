using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numlib.NET.Structures;

namespace Structures.Tests
{
    [TestClass]
    public class RVectorTests
    {
        [TestMethod]
        public void TestSwapVectorEntries()
        {
            double[] vector = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] expectedVector = { 1, 6, 3, 4, 5, 2, 7, 8, 9 };
            var rvector = new RVector(vector);
            var expectedRVector = new RVector(expectedVector);
            rvector.SwapVectorEntries(1, 5);
            Assert.AreEqual(expectedRVector,rvector);
        }

        [TestMethod]
        public void TestToString()
        {
            double[] vector = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var rvector = new RVector(vector);
            var expectedString = "[1,2,3,4,5,6,7,8,9]";
            Assert.AreEqual(rvector.ToString(), expectedString);
        }

        [TestMethod]
        public void TestScalarMult()
        {
            double[] vector = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var rvector = new RVector(vector);
            var rvector2 = 2 * rvector;
            var expectedVector = new RVector(new[] { 2.0, 4, 6, 8, 10, 12, 14, 16, 18 });
            Assert.AreEqual(rvector2, expectedVector);
        }

        [TestMethod]
        public void TestAddition()
        {
            double[] vector = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] vector2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] sumVector = { 2, 4, 6, 8, 10, 12, 14, 16, 18 };
            var rvector1 = new RVector(vector);
            var rvector2 = new RVector(vector2);
            var expectedVector = new RVector(sumVector);
            Assert.AreEqual(expectedVector, rvector1 + rvector2);
        }

        [TestMethod]
        public void TestSubstration()
        {
            double[] vector = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            double[] vector2 = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            double[] sumVector = { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            var rvector1 = new RVector(vector);
            var rvector2 = new RVector(vector2);
            var expectedVector = new RVector(sumVector);
            Assert.AreEqual(expectedVector, rvector1 - rvector2);
        }

        [TestMethod]
        public void TestDotProduct()
        {
            double[] vector = { 1, 2, 3, 1};
            double[] vector2 = { 0, 1, 2, 1 };
            var rvector1 = new RVector(vector);
            var rvector2 = new RVector(vector2);
            double expected = 9;
            Assert.AreEqual(expected, RVector.DotProduct(rvector1, rvector2));
        }

        [TestMethod]
        public void TestNorm()
        {
            double[] vector = { 1, 2, 3};
            var rvector = new RVector(vector);
            double expected = Math.Sqrt(14);
            Assert.AreEqual(expected, rvector.GetNorm());
        }

        [TestMethod]
        public void TestNormSquare()
        {
            double[] vector = { 1, 2, 3 };
            var rvector = new RVector(vector);
            double expected = 14;
            Assert.AreEqual(expected, rvector.GetNormSquare());
        }
    }
}
