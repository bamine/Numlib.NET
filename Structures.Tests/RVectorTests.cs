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
    }
}
