using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using AdventOfCode2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AdventOfCode2019.WireIntersector;

namespace AdventOfCodeTests
{
    [TestClass]
    public class WireIntersectorTests
    {
        [TestMethod]
        public void Creation()
        {
            var intersector = new WireIntersector();
        }

        [DataTestMethod]
        [DataRow(0,1)]
        [DataRow(0,2)]
        [DataRow(0,3)]
        [DataRow(0,4)]
        [DataRow(0,5)]
        [DataRow(0,6)]
        [DataRow(0,7)]
        public void WireGoesUp(int x , int y)
        {
            var wire = new Wire("U7");
            CollectionAssert.Contains(wire.Points, new Point(x,y));
        }

        [DataTestMethod]
        [DataRow(0, 7)]
        [DataRow(1, 7)]
        [DataRow(2, 7)]
        [DataRow(3, 7)]
        [DataRow(4, 7)]
        [DataRow(5, 7)]
        [DataRow(6, 7)]
        public void WireGoesUpThenRight(int x, int y)
        {
            var wire = new Wire("U7,R6");
            CollectionAssert.Contains(wire.Points, new Point(x, y));
        }

        [DataTestMethod]
        [DataRow(6, 7)]
        [DataRow(6, 6)]
        [DataRow(6, 5)]
        [DataRow(6, 4)]
        [DataRow(6, 3)]
        public void WireGoesUpThenRightThenDown(int x, int y)
        {
            var wire = new Wire("U7,R6,D4");
            CollectionAssert.Contains(wire.Points, new Point(x, y));
        }

        [DataTestMethod]
        [DataRow(6, 3)]
        [DataRow(5, 3)]
        [DataRow(4, 3)]
        [DataRow(3, 3)]
        public void WireGoesUpThenRightThenDownThenLeft(int x, int y)
        {
            var wire = new Wire("U7,R6,D4,L4");
            CollectionAssert.Contains(wire.Points, new Point(x, y));
        }

        [DataTestMethod]
        [DataRow(100, 22)]
        [DataRow(-5, 22)]
        [DataRow(-5, -22)]
        public void WireDoesNotContainPoints(int x, int y)
        {
            var wire = new Wire("U7,R6,D4,L4");
            CollectionAssert.DoesNotContain(wire.Points, new Point(x, y));
        }

        [TestMethod]
        public void FindIntersections()
        {
            var wireA = new Wire("R8,U5,L5,D3");
            var wireB = new Wire("U7,R6,D4,L4");
            var intersector = new WireIntersector();
            var intersections = intersector.FindIntersections(wireA, wireB);
            var expected = new List<Point> {new Point(6, 5), new Point(3, 3)};
            CollectionAssert.AreEquivalent(expected, intersections);
        }

        [TestMethod]
        public void FindMinimumIntersection()
        {
            var wireA = new Wire("R8,U5,L5,D3");
            var wireB = new Wire("U7,R6,D4,L4");
            var intersector = new WireIntersector();
            var min = intersector.MinimumIntersection(wireA, wireB);
            Assert.AreEqual(new Point(3,3), min);
        }
    }
}
