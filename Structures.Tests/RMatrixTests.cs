using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numlib.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures.Tests
{
    [TestClass]
    public class RMatrixTests
    {
        [TestMethod]
        public void TestMultiplication()
        {
            var A = new RMatrix(new double[3,3] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            var B = new RMatrix(new double[3, 3] { { 1, 2, 3 }, { 1, 1, 1 }, { 1, 2, 1 } });
            var actual = A * B;
            var expected = B;
            Assert.IsTrue(actual == expected);
        }
    }
}
