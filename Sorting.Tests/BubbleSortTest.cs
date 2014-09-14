using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Sorting.Tests
{
    [TestClass]
    public class BubbleSortTest
    {
        [TestMethod]
        public void TestBubbleSort1()
        {
            int[] x = { 8, 6, 4, 7, 5, 3, 1, 9, 2 };
            int[] sorted = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            BubbleSorter.Sort1(ref x);
            Assert.IsTrue(x.SequenceEqual(sorted));
        }

        [TestMethod]
        public void TestBubbleSort2()
        {
            int[] x = { 8, 6, 4, 7, 5, 3, 1, 9, 2 };
            int[] sorted = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            BubbleSorter.Sort2(ref x);
            Assert.IsTrue(x.SequenceEqual(sorted));
        }

        [TestMethod]
        public void TestBubbleSort3()
        {
            int[] x = { 8, 6, 4, 7, 5, 3, 1, 9, 2 };
            int[] sorted = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            BubbleSorter.Sort3(ref x);
            Assert.IsTrue(x.SequenceEqual(sorted));
        }

        [TestMethod]
        public void TestBubbleSort4()
        {
            int[] x = { 8, 6, 4, 7, 5, 3, 1, 9, 2 };
            int[] sorted = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            BubbleSorter.Sort4(ref x);
            Assert.IsTrue(x.SequenceEqual(sorted));
        }
    }
}
