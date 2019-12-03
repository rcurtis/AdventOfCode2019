using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class OpCodeReaderTests
    {
        [TestMethod]
        public void Fist_Example()
        {
            var input = new List<int>
            {
                1, 9, 10, 3,
                2, 3, 11, 0,
                99,
                30, 40, 50
            };

            var expected = new List<int>
            {
                3500,9,10,70,
                2,3,11,0,
                99,
                30,40,50
            };

            var reader = new OpCodeReader();
            var result = reader.Process(input);

            CollectionAssert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(new[] {1, 0, 0, 0, 99}, new[] {2, 0, 0, 0, 99})]
        [DataRow(new[] { 2, 3, 0, 3, 99 }, new[] { 2, 3, 0, 6, 99 })]
        [DataRow(new[] { 2, 4, 4, 5, 99, 0 }, new[] { 2, 4, 4, 5, 99, 9801 })]
        [DataRow(new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void More(int[] input, int[] expected)
        {
            var reader = new OpCodeReader();
            var result = reader.Process(input.ToList());
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
